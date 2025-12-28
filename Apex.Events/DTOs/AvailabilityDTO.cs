namespace Apex.Events.DTOs
{
    public class AvailabilityDTO
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public DateTime Date { get; set; }
        public double CostPerHour { get; set; } 
    }
}
