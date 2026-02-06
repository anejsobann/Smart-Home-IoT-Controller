💡 SmartHome Light Control (IoT)
📘 Application Description

SmartHome Light Control (IoT) is a beginner-friendly Internet of Things (IoT) application developed in C#.
The application demonstrates how a smart home device (a light) can be controlled remotely using a network connection 🌐.

The project is split into two simple parts:

🧠 Backend API – simulates a smart light device.

💻 Console Client – allows the user to control the light from the terminal.

The client communicates with the device using HTTP REST requests, a common approach in IoT and smart home systems 🔌.

⚙️ Requirements

.NET SDK installed (version 7 or higher)

Terminal / Command Line

Any operating system (Windows, macOS, Linux)

📁 Project Structure
SmartHomeProject
│
├── SmartHomeDeviceApi      // Backend (smart device simulation)
└── SmartHomeConsoleApp     // Console client (user interface)

🧭 Step-by-Step Setup Guide
🟢 Step 1: Create the Solution

Open a terminal and navigate to the folder where you want to store the project.

mkdir SmartHomeProject
cd SmartHomeProject
dotnet new sln -n SmartHomeProject

🟢 Step 2: Create the Backend API (Smart Device)

Create an ASP.NET Core web project:

dotnet new web -n SmartHomeDeviceApi
dotnet sln SmartHomeProject.sln add SmartHomeDeviceApi/SmartHomeDeviceApi.csproj

🟢 Step 3: Implement the Backend Logic

Open the file:

SmartHomeDeviceApi/Program.cs


Replace its contents with:

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

bool lightOn = false;

app.MapGet("/api/light/state", () => Results.Ok(new { on = lightOn }));

app.MapPost("/api/light/on", () =>
{
    lightOn = true;
    return Results.Ok(new { on = lightOn });
});

app.MapPost("/api/light/off", () =>
{
    lightOn = false;
    return Results.Ok(new { on = lightOn });
});

app.Run();

🟢 Step 4: Run the Backend 🚀

Start the backend API:

cd SmartHomeDeviceApi
dotnet run


You will see output similar to:

Now listening on: http://localhost:5213


⚠️ Important: Write down the port number (e.g. 5213).
The backend must remain running.

🟢 Step 5: Create the Console Client 💻

Open a new terminal window and navigate back to the project root:

cd ../
dotnet new console -n SmartHomeConsoleApp
dotnet sln SmartHomeProject.sln add SmartHomeConsoleApp/SmartHomeConsoleApp.csproj

🟢 Step 6: Implement the Console Client

Open the file:

SmartHomeConsoleApp/Program.cs


Replace its contents with:

using System.Net.Http.Json;

const string BaseUrl = "http://localhost:5213"; // Change port if needed

using var http = new HttpClient();

while (true)
{
    Console.WriteLine("\n=== SMART HOME LIGHT (IoT) ===");
    Console.WriteLine("1 - Turn ON 💡");
    Console.WriteLine("2 - Turn OFF 🌑");
    Console.WriteLine("3 - Show state 📊");
    Console.WriteLine("0 - Exit ❌");
    Console.Write("Choice: ");

    var choice = Console.ReadLine();

    try
    {
        if (choice == "1")
        {
            await http.PostAsync($"{BaseUrl}/api/light/on", null);
            Console.WriteLine("Light turned ON 💡");
        }
        else if (choice == "2")
        {
            await http.PostAsync($"{BaseUrl}/api/light/off", null);
            Console.WriteLine("Light turned OFF 🌑");
        }
        else if (choice == "3")
        {
            var state = await http.GetFromJsonAsync<LightState>($"{BaseUrl}/api/light/state");
            Console.WriteLine($"Current state: {(state?.on == true ? "ON 💡" : "OFF 🌑")}");
        }
        else if (choice == "0")
        {
            break;
        }
        else
        {
            Console.WriteLine("Invalid choice ⚠️");
        }
    }
    catch
    {
        Console.WriteLine("Error: Cannot connect to the backend API ❌");
        Console.WriteLine("Make sure the backend is running and the BaseUrl is correct.");
    }
}

public class LightState
{
    public bool on { get; set; }
}

🟢 Step 7: Run the Console Client ▶️
cd SmartHomeConsoleApp
dotnet run


Use the menu to control the smart light.

🔍 How the Application Works

The backend API simulates a smart light device 💡.

The console client sends HTTP requests 📡.

The backend updates and returns the current light state.

The user can remotely control and monitor the device 🏠.

✅ Result

Remote control of a smart home device

Clear demonstration of IoT communication

Simple and understandable client–server architecture
