using System.ComponentModel.DataAnnotations;

namespace Apex.Events.Data
{
    public class Staff
    {
        // Attributes
        [Key]
        [Required]
        public int EventStaffId { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Role { get; set; } = string.Empty;
        // Navigation property to the Staffing entity.
        public List<Staffing>? Staffings { get; set; }

        // Constructor
        public Staff()
        {
        }
    }
}
