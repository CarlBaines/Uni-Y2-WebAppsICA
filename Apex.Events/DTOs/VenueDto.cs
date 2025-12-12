using System.ComponentModel.DataAnnotations;

namespace Apex.Events.DTOs
{
    public class VenueDto
    {
        [Key, MaxLength(5)]
        public required string Code { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Range(1, Int32.MaxValue)]
        public int Capacity { get; set; }
    }
}
