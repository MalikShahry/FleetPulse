# FleetPulse — Real-Time Fleet Tracking Platform


**FleetPulse** is an end-to-end real-time vehicle tracking platform built with **C#/.NET, ASP.NET Core, SignalR, and Leaflet.js**.
It simulates a fleet of vehicles, streams GPS data to a backend API, and visualizes live locations on an interactive web map.


---


## Features


- Real-time vehicle tracking using **ASP.NET Core Web API** and **SignalR**.
- **Path-based vehicle simulator** that generates smooth GPS movement along predefined routes.
- Interactive web map visualization with **Leaflet.js**, updating vehicle positions dynamically.
- Handles **cross-origin SignalR/WebSocket connections** and real-time client synchronization.
- Supports multiple vehicles (extendable) via the simulator.


---


## 🛠 Tech Stack


| Layer | Technology |
|------------------------|------------------------------------|
| Backend API | C#, ASP.NET Core, SignalR |
| Real-Time Communication| SignalR WebSockets |
| Vehicle Simulator | C# Console App |
| Frontend Visualization | Leaflet.js, HTML/CSS, JavaScript |
| HTTP Client | HttpClient in C# for simulator |


---

## 🏗 Getting Started


### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download)
- Modern browser (Chrome, Edge, Firefox)


### Steps


1. **Run the backend API**
cd FleetPulse/src/FleetPulse.Api
dotnet run

2. **Run the simulator**
cd ../FleetPulse.Simulator
dotnet run

3. **Run the dashboard**
cd FleetPulse/src/FleetPulse.Web
dotnet run

4. **Navigate to dashboard**
A link to http://localhost:5035 should appear in the console, from there you will be able to see blue dots (vehicles) moving
across the map

5. **Enjoy :)**
