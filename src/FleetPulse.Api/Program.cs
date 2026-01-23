using FleetPulse.Api.Services;
using FleetPulse.Api.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<LocationService>();
builder.Services.AddSignalR();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.MapHub<LocationHub>("/hubs/location");

app.MapGet("/", () => Results.Ok("FleetPulse API running"));


app.Run();
