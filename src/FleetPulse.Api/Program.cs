using FleetPulse.Api.Services;
using FleetPulse.Api.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<LocationService>();
builder.Services.AddSignalR();
builder.Services.AddControllers();

// Add CORS for SignalR
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5167", "https://localhost:7249")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

var app = builder.Build();

// Apply CORS middleware before mapping endpoints
app.UseCors();

app.MapControllers();
app.MapHub<LocationHub>("/hubs/location");

app.MapGet("/", () => Results.Ok("FleetPulse API running"));

app.Run();
