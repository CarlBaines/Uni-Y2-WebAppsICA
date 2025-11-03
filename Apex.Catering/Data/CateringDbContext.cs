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
            DbPath = Path.Combine(path, "C# Databases/ICA Databases", "catering.db");
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
                .IsRequired();


            // Insert seed data for Menus
            modelBuilder.Entity<Menu>().HasData(
                new Menu { MenuId = 1, MenuName = "Conference Menu" },
                new Menu { MenuId = 2, MenuName = "Party Menu" },
                new Menu { MenuId = 3, MenuName = "Wedding Menu" }
            );
        }
    }
}
