using System.ComponentModel.DataAnnotations;

namespace Apex.Events.DTOs
{
    public class ReservationPostDTO
    {
        [Required, DataType(DataType.Date)]
        public DateTime EventDate { get; set; }
        [Required, MinLength(5), MaxLength(5)]
        public string VenueCode { get; set; } = string.Empty;
    }
}
