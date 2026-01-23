using FleetPulse.Api.Models;

namespace FleetPulse.Api.Services
{
    
    public class LocationService
    {
        private readonly Dictionary<string, VehicleLocation> _locations = new();
        
        public VehicleLocation? GetLatest(string vehicleId)
        {
            _locations.TryGetValue(vehicleId, out var location);
            return location;
        }
        
        public void UpdateLocation(VehicleLocation location)
        {
            _locations[location.VehicleId] = location;
        }
        
        public IReadOnlyDictionary<string, VehicleLocation> GetAll() => _locations;

    }
    
}