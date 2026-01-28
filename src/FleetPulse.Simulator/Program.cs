using System.Net.Http.Json;

string vehicleId = "vehicle-001";

var client = new HttpClient { BaseAddress = new Uri("http://localhost:5035/") };

var rand = new Random();


double latitude = 51.045;
double longitude = -114.057;


while (true)
{
    // simulate movement
    latitude += (rand.NextDouble() - 0.5) * 0.001;
    longitude += (rand.NextDouble() - 0.5) * 0.001;


    var body = new
    {
        Latitude = latitude,
        Longitude = longitude
    };

    await client.PostAsJsonAsync($"/api/vehicles/{vehicleId}/location", body);

    Console.WriteLine($"Sent location: {latitude}, {longitude}");

    await Task.Delay(2000);
}