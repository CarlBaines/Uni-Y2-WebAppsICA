using System.ComponentModel.DataAnnotations;

namespace Apex.Catering.Data
{
    public class Menu
    {
        [Required]
        public int MenuId { get; set; }
        [Required]
        [MaxLength(50)]
        public string MenuName { get; set; } = string.Empty;
        // Navigation property to the FoodBooking entity.
        // One menu can relate to many food bookings (the one side of the one-to-many).
        public List<FoodBooking>? FoodBookings { get; set; }
    }
}
