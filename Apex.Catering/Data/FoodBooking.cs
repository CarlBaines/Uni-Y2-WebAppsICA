using System.ComponentModel.DataAnnotations;

namespace Apex.Catering.Data
{
    public class FoodBooking
    {
        [Required]
        public int FoodBookingId { get; set; }
        [Required]
        public int EventId { get; set; }
        [Required]
        public int ClientReferenceId { get; set; }
        [Required]
        public int NumberOfGuests { get; set; }
        [Required]
        // Foreign key to the Menu entity.
        public int MenuId { get; set; }
        // Navigation property to the Menu entity.
        // Many food bookings relate to one Menu (the many side of the many-to-one).
        public Menu? Menu { get; set; }
    }
}
