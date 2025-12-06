using System.ComponentModel.DataAnnotations;

namespace Apex.Events.Data
{
    public class Guest
    {
        // Attributes
        [Required]
        public int GuestId { get; set; }
        [MaxLength(50)] 
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        // Navigation property to the GuestBooking entity.
        public List<GuestBooking>? GuestBookings { get; set; }

        // Constructor
        public Guest()
        {
        }
    }
}
 