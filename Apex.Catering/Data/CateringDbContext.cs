using Microsoft.EntityFrameworkCore;

namespace Apex.Catering.Data
{
    public class CateringDbContext : DbContext
    {
        // Instance names become table names in the database
        public DbSet<FoodBooking> FoodBookings { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuFoodItem> MenuFoodItems { get; set; }
        private string DbPath { get; set; } = string.Empty;

        // Constructor
        public CateringDbContext()
        {
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Combine(path, "C# Databases/ICA Databases", "Apex.Catering.db");

            var dir = Path.GetDirectoryName(DbPath);
            if (!string.IsNullOrWhiteSpace(dir))
            {    
               Directory.CreateDirectory(dir);   
            }
        }

        // Sets the database to use SQLite and the database file path
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Models the many-to-one relationship between FoodBooking and Menu
            modelBuilder.Entity<FoodBooking>()
                .HasOne(fb => fb.Menu)
                .WithMany(m => m.FoodBookings)
                .HasForeignKey(fb => fb.MenuId)
                .OnDelete(DeleteBehavior.Restrict) // Prevents cascade delete
                .IsRequired();

            // Models the many-to-many relationship between Menu and FoodItem via MenuFoodItem
            // Composite primary key
            modelBuilder.Entity<MenuFoodItem>()
                .HasKey(mfi => new { mfi.MenuId, mfi.FoodItemId });

            modelBuilder.Entity<MenuFoodItem>()
                .HasOne<Menu>()
                .WithMany()
                .HasForeignKey(mfi => mfi.MenuId)
                .OnDelete(DeleteBehavior.Cascade); // Prevents cascade delete

            modelBuilder.Entity<MenuFoodItem>()
                .HasOne<FoodItem>()
                .WithMany()
                .HasForeignKey(mfi => mfi.FoodItemId)
                .OnDelete(DeleteBehavior.Cascade); // Prevents cascade delete

            // Insert seed data for Menus
            modelBuilder.Entity<Menu>().HasData(
                new Menu { MenuId = 1, MenuName = "Conference Menu" },
                new Menu { MenuId = 2, MenuName = "Party Menu" },
                new Menu { MenuId = 3, MenuName = "Wedding Menu" }
            );

            // Insert seed data for food bookings
            modelBuilder.Entity<FoodBooking>().HasData(
                new FoodBooking { FoodBookingId = 1, ClientReferenceId = 1001, NumberOfGuests = 50, MenuId = 1 },
                new FoodBooking { FoodBookingId = 2, ClientReferenceId = 1002, NumberOfGuests = 100, MenuId = 2 },
                new FoodBooking { FoodBookingId = 3, ClientReferenceId = 1003, NumberOfGuests = 200, MenuId = 3 }
            );

            // Insert seed data for FoodItems
            modelBuilder.Entity<FoodItem>().HasData(
                new FoodItem { FoodItemId = 1, Description = "Chicken Sandwich", UnitPrice = 5.99 },
                new FoodItem { FoodItemId = 2, Description = "Veggie Wrap", UnitPrice = 4.99 },
                new FoodItem { FoodItemId = 3, Description = "Caesar Salad", UnitPrice = 3.99 }
            );

            // Insert seed data for MenuFoodItems
            modelBuilder.Entity<MenuFoodItem>().HasData(
                new MenuFoodItem { MenuId = 1, FoodItemId = 3},
                new MenuFoodItem { MenuId = 2, FoodItemId = 1},
                new MenuFoodItem { MenuId = 2, FoodItemId = 2}
            );
        }
    }
}
