using Microsoft.EntityFrameworkCore;

namespace Apex.Catering.Data
{
    public class DbTestDataInitialiser
    {
        private readonly CateringDbContext _context;
        // Constructor
        public DbTestDataInitialiser(CateringDbContext context)
        {
            _context = context;
        }

        public void Initialise()
        {
            _context.Database.Migrate();
            if (_context.Menus.Any())
            {
                return; // Database has already been seeded.
            }
            // Seed food bookings
            var foodBookings = new[]
            {
                new FoodBooking { FoodBookingId = 1, EventId = 1, ClientReferenceId = 1001, NumberOfGuests = 50, MenuId = 1 },
                new FoodBooking { FoodBookingId = 2, EventId = 2, ClientReferenceId = 1002, NumberOfGuests = 75, MenuId = 2 },
                new FoodBooking { FoodBookingId = 3, EventId = 3, ClientReferenceId = 1003, NumberOfGuests = 100, MenuId = 3 }
            };
            _context.FoodBookings.AddRange(foodBookings);
            // Seed food items
            var foodItems = new[]
            {
                new FoodItem { FoodItemId = 1, ItemName = "Caesar Salad", Description = "Fresh romaine lettuce with Caesar dressing", UnitPrice = 5.99 },
                new FoodItem { FoodItemId = 2, ItemName = "Grilled Chicken", Description = "Juicy grilled chicken breast with herbs", UnitPrice = 12.99 },
                new FoodItem { FoodItemId = 3, ItemName = "Chocolate Cake", Description = "Decadent chocolate cake with ganache", UnitPrice = 6.49 },
                new FoodItem { FoodItemId = 4, ItemName = "Vegetable Stir Fry", Description = "Mixed vegetables stir-fried with soy sauce", UnitPrice = 9.99 },
                new FoodItem { FoodItemId = 5, ItemName = "Fruit Platter", Description = "Assorted fresh fruits", UnitPrice = 7.99 }
            };
            _context.FoodItems.AddRange(foodItems);
            // Seed menus
            var menus = new[]
            {
                new Menu { MenuId = 1, MenuName = "Standard Menu" },
                new Menu { MenuId = 2, MenuName = "Conference Menu" },
                new Menu { MenuId = 3, MenuName = "Party Menu" },
                new Menu { MenuId = 4, MenuName = "Wedding Menu" }
            };
            _context.Menus.AddRange(menus);
            // Seed menu food items
            var menuFoodItems = new[]
            {
                new MenuFoodItem { MenuId = 1, FoodItemId = 1 },
                new MenuFoodItem { MenuId = 1, FoodItemId = 2 },
                new MenuFoodItem { MenuId = 1, FoodItemId = 3 },
                new MenuFoodItem { MenuId = 2, FoodItemId = 1 },
                new MenuFoodItem { MenuId = 2, FoodItemId = 4 },
                new MenuFoodItem { MenuId = 2, FoodItemId = 5 },
                new MenuFoodItem { MenuId = 3, FoodItemId = 2 },
                new MenuFoodItem { MenuId = 3, FoodItemId = 3 },
                new MenuFoodItem { MenuId = 3, FoodItemId = 5 }
            };
            _context.MenuFoodItems.AddRange(menuFoodItems);

            _context.SaveChanges();
        }
    }
}
