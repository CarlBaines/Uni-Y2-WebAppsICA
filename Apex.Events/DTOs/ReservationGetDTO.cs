namespace Apex.Events.DTOs
{
    public class ReservationGetDTO
    {
        public string Reference { get; set; } = string.Empty;
        public DateTime EventDate { get; set; }
        public string VenueCode { get; set; } = string.Empty;
        public DateTime WhenMade { get; set; }
    }
}
