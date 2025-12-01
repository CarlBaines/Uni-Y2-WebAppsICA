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
                .OnDelete(DeleteBehavior.Cascade); // Implements cascade delete

            modelBuilder.Entity<MenuFoodItem>()
                .HasOne<FoodItem>()
                .WithMany()
                .HasForeignKey(mfi => mfi.FoodItemId)
                .OnDelete(DeleteBehavior.Cascade); // Implements cascade delete
        }
    }
}
