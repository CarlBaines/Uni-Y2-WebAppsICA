using System.ComponentModel.DataAnnotations;

namespace Apex.Events.Data
{
    public class Staffing
    {
        // Attributes
        [Required]
        public int StaffingId { get; set; }
        [Required]
        [MaxLength(50)]
        public string StaffingName { get; set; } = string.Empty;
        [Required]
        // Foreign key to the Staff entity.
        public int EventStaffId { get; set; }
        // Foreign key to the Event entity.
        public int EventId { get; set; }
        // Navigation property to the Event entity.
        public Event? Event { get; set; }
        // Navigation property to the Staff entity.
        public Staff? Staff { get; set; }

        // Constructor
        public Staffing()
        {
        }
    }
}
