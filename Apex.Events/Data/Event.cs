using System.ComponentModel.DataAnnotations;

namespace Apex.Events.Data
{
    public class Event
    {
        // Attributes
        [Required]
        public int EventId { get; set; }
        [Required]
        [MaxLength(50)]
        public string EventName { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Date)]
        public DateOnly EventDate { get; set; }
        [Required]
        [MaxLength(50)]
        public string EventType { get; set; } = string.Empty;
        // Foreign key to the Venue entity.
        [Required]
        public string VenueCode { get; set; } = string.Empty;
        // Soft delete flag to indicate if the event is cancelled or not.
        public bool IsCancelled { get; set; } = false;
        // Navigation property to the Staffing entity.
        public List<Staffing>? Staffings { get; set; }
        // Navigation property to the GuestBooking entity.
        public List<GuestBooking>? GuestBookings { get; set; }
        // Constructor
        public Event()
        {
        }
    }
}
