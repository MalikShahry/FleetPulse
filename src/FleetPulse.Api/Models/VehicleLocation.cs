
namespace FleetPulse.Api.Models
{
    public class VehicleLocation
    {
        public string? VehicleId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}