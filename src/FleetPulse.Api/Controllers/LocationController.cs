using FleetPulse.Api.Models;
using FleetPulse.Api.Services;
using FleetPulse.Api.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace FleetPulse.Api.Controllers
{
    
    [ApiController]
    [Route("api/vehicles")]
    public class LocationController : ControllerBase
    {
        private readonly LocationService _locationService;
        private readonly IHubContext<LocationHub> _hub;
        
        public LocationController(LocationService service, IHubContext<LocationHub> hub)
        {
            _locationService = service;
            _hub = hub;
        }
        
        [HttpPost("{id}/location")]
        public async Task<IActionResult> UpdateLocation(string id, [FromBody] VehicleLocation location)
        {
            location.VehicleId = id;
            location.Timestamp = DateTime.UtcNow;
            
            _locationService.UpdateLocation(location);
            
            // broadcast update
            await _hub.Clients.All.SendAsync(
                "Location Updated",
                id,
                location.Latitude,
                location.Longitude,
                location.Timestamp
            );
            
            return Ok();
            
        }
        
        [HttpGet("{id}/location")]
        public IActionResult GetLocation(string id)
        {
            var loc = _locationService.GetLatest(id);
            return loc == null ? NotFound(): Ok(loc);
        }
        
    }
    
}