using System.ComponentModel.DataAnnotations;

namespace Apex.Events.Data
{
    public class GuestBooking
    {
        [Required]
        public int GuestBookingId { get; set; }
        // Foreign key to the Guest entity.
        [Required]
        public int GuestId { get; set; }
        [Required]
        public int EventId { get; set; }
        // Navigation property to the Guest entity.
        public Guest? Guest { get; set; }
        // Navigation property to the Event entity.
        public Event? Event { get; set; }

        // Attendance attributes
        public bool IsAttending { get; set; } = false;
        public DateTime? CheckInTime { get; set; }

        // Constructor
        public GuestBooking()
        {
        }
    }
}
