using System.Net.Http.Json;

string vehicleId = "vehicle-001";

var client = new HttpClient { BaseAddress = new Uri("http://localhost:5035/") };

var rand = new Random();

var path = new List<(double Lat, double Lon)>
{
    (51.0450, -114.0570),
    (51.0465, -114.0600),
    (51.0480, -114.0625),
    (51.0495, -114.0600),
    (51.0505, -114.0570),
    (51.0485, -114.0540),
    (51.0460, -114.0555),
};

int targetIndex = 1;
double latitude = path[0].Lat;
double longitude = path[0].Lon;
double stepSize = 0.0002; //20m per update

while (true)
{
    // simulate movement

    var target = path[targetIndex];

    (latitude, longitude) = MoveTowards(
        latitude, 
        longitude, 
        target.Lat, 
        target.Lon, 
        stepSize);


    var body = new
    {
        Latitude = latitude,
        Longitude = longitude
    };

    await client.PostAsJsonAsync($"/api/vehicles/{vehicleId}/location", body);

    Console.WriteLine($"Sent location for Vehicle {vehicleId} at: {latitude}, {longitude}");

    await Task.Delay(2000);
}

static (double lat, double lon) MoveTowards(
    double currentLat, 
    double currentLon, 
    double targetLat, 
    double targetLon, 
    double stepSize)
{
    double dLat = targetLat - currentLat;
    double dLon = targetLon - currentLon;
    double distance = Math.Sqrt(dLat * dLat + dLon * dLon);

    if (distance <= stepSize || distance == 0)
    {
        return (targetLat, targetLon);
    }
    else
    {
        double ratio = stepSize / distance;
        double newLat = currentLat + dLat * ratio;
        double newLon = currentLon + dLon * ratio;
        return (newLat, newLon);
    }
}