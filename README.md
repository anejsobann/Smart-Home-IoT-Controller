<h1>💡 SmartHome Light Control (IoT)</h1>

<h2>📘 Application Description</h2>

<p>
<strong>SmartHome Light Control (IoT)</strong> is a beginner-friendly Internet of Things (IoT)
application developed in C#.
The application demonstrates how a smart home device (a light) can be controlled remotely
using a network connection 🌐.
</p>

<p>The project consists of three parts:</p>
<ul>
  <li>🧠 <strong>Backend API</strong> – simulates a smart light device and exposes REST endpoints.</li>
  <li>💻 <strong>Console Client</strong> – allows the user to control the light from the terminal.</li>
  <li>🌐 <strong>Web Frontend (HTML + CSS)</strong> – provides a simple browser-based user interface.</li>
</ul>

<p>
All components communicate using <strong>HTTP (REST)</strong>,
which is a common approach in IoT systems 🔌.
</p>

<hr>

<h2>⚙️ Requirements</h2>
<ul>
  <li>.NET SDK (version 7 or higher)</li>
  <li>Terminal / Command Line</li>
  <li>Modern web browser (for HTML frontend)</li>
  <li>Windows, macOS, or Linux</li>
</ul>

<hr>

<h2>📁 Project Structure</h2>

<pre>
SmartHomeProject
│
├── SmartHomeDeviceApi
│   ├── Program.cs
│   └── wwwroot
│       ├── index.html     // Web frontend (HTML)
│       └── style.css      // Web frontend styling
│
└── SmartHomeConsoleApp
    └── Program.cs         // Console client
</pre>

<hr>

<h2>🧭 Step-by-Step Setup Guide</h2>

<h3>Step 1: Create the Solution</h3>
<p>Create a new project folder and solution:</p>

<pre>
mkdir SmartHomeProject
cd SmartHomeProject
dotnet new sln -n SmartHomeProject
</pre>

<h3>Step 2: Create the Backend API</h3>
<p>Create an ASP.NET Core web project:</p>

<pre>
dotnet new web -n SmartHomeDeviceApi
dotnet sln SmartHomeProject.sln add SmartHomeDeviceApi/SmartHomeDeviceApi.csproj
</pre>

<h3>Step 3: Implement the Backend Logic</h3>
<p>Edit the file <code>SmartHomeDeviceApi/Program.cs</code> and replace its content:</p>

<pre>
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Enable serving static HTML and CSS
app.UseDefaultFiles();
app.UseStaticFiles();

// Smart light state (simulation)
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
</pre>

<h3>Step 4: Run the Backend</h3>
<p>Start the backend API:</p>

<pre>
cd SmartHomeDeviceApi
dotnet run
</pre>

<p>
The terminal will display the server address, for example:
<code>http://localhost:5213</code>.
Keep the backend running.
</p>

<p>
The web frontend will be available at:
<code>http://localhost:5213/</code>
</p>

<h3>Step 5: Create the Console Client</h3>
<p>Open a new terminal and create the console application:</p>

<pre>
cd ..
dotnet new console -n SmartHomeConsoleApp
dotnet sln SmartHomeProject.sln add SmartHomeConsoleApp/SmartHomeConsoleApp.csproj
</pre>

<h3>Step 6: Implement the Console Client</h3>
<p>Edit the file <code>SmartHomeConsoleApp/Program.cs</code>:</p>

<pre>
using System.Net.Http.Json;

const string BaseUrl = "http://localhost:5213";

using var http = new HttpClient();

while (true)
{
    Console.WriteLine("=== SMART HOME LIGHT (IoT) ===");
    Console.WriteLine("1 - Turn ON");
    Console.WriteLine("2 - Turn OFF");
    Console.WriteLine("3 - Show state");
    Console.WriteLine("0 - Exit");
    Console.Write("Choice: ");

    var choice = Console.ReadLine();

    try
    {
        if (choice == "1")
        {
            await http.PostAsync($"{BaseUrl}/api/light/on", null);
            Console.WriteLine("Light turned ON");
        }
        else if (choice == "2")
        {
            await http.PostAsync($"{BaseUrl}/api/light/off", null);
            Console.WriteLine("Light turned OFF");
        }
        else if (choice == "3")
        {
            var state = await http.GetFromJsonAsync<LightState>($"{BaseUrl}/api/light/state");
            Console.WriteLine(state?.on == true ? "ON" : "OFF");
        }
        else if (choice == "0")
        {
            break;
        }
    }
    catch
    {
        Console.WriteLine("Error: Cannot connect to backend API.");
    }
}

public class LightState
{
    public bool on { get; set; }
}
</pre>

<h3>Step 7: Run the Console Client</h3>

<pre>
cd SmartHomeConsoleApp
dotnet run
</pre>

<hr>

<h2>🌐 Web Frontend (HTML + CSS)</h2>

<p>
The project includes a simple web-based frontend implemented using HTML, CSS, and JavaScript.
The frontend is served directly by the ASP.NET Core backend from the <code>wwwroot</code> folder.
</p>

<p>
The web interface allows the user to:
</p>
<ul>
  <li>Turn the smart light ON and OFF using buttons</li>
  <li>View the current light status in real time</li>
  <li>Control the device from a browser or smartphone</li>
</ul>

<p>
The frontend communicates with the backend API using JavaScript <code>fetch</code> requests.
</p>

<hr>

<h2>🔍 How the Application Works</h2>
<ol>
  <li>The backend API simulates a smart light device.</li>
  <li>The console client and web frontend send HTTP requests.</li>
  <li>The backend updates and returns the light state.</li>
  <li>The user controls the device remotely via console or browser.</li>
</ol>

<hr>

<h2>✅ Result</h2>
<ul>
  <li>Remote control of a smart home device</li>
  <li>Console-based and browser-based user interface</li>
  <li>Clear demonstration of IoT communication</li>
  <li>Simple and extensible client–server architecture</li>
</ul>

<hr>
