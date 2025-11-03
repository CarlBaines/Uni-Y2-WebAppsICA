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
    }
}
