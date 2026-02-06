<h1>💡 SmartHome Light Control (IoT)</h1>

<h2>📘 Application Description</h2>

<p>
<strong>SmartHome Light Control (IoT)</strong> is a beginner-friendly Internet of Things (IoT)
application developed in C#.
The application demonstrates how a smart home device (a light) can be controlled remotely
using a network connection 🌐.
</p>

<p>The project consists of two parts:</p>
<ul>
  <li>🧠 <strong>Backend API</strong> – simulates a smart light device.</li>
  <li>💻 <strong>Console Client</strong> – allows the user to control the light from the terminal.</li>
</ul>

<p>
The client communicates with the device using <strong>HTTP (REST)</strong>,
which is a common approach in IoT systems 🔌.
</p>

<hr>

<h2>⚙️ Requirements</h2>
<ul>
  <li>.NET SDK (version 7 or higher)</li>
  <li>Terminal / Command Line</li>
  <li>Windows, macOS, or Linux</li>
</ul>

<hr>

<h2>📁 Project Structure</h2>

<pre>
SmartHomeProject
│
├── SmartHomeDeviceApi      // Backend (smart device simulation)
└── SmartHomeConsoleApp     // Console client (user interface)
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

<h2>🔍 How the Application Works</h2>
<ol>
  <li>The backend API simulates a smart light.</li>
  <li>The console client sends HTTP requests.</li>
  <li>The backend updates and returns the light state.</li>
  <li>The user controls the device remotely.</li>
</ol>

<hr>

<h2>✅ Result</h2>
<ul>
  <li>Remote control of a smart home device</li>
  <li>Clear demonstration of IoT communication</li>
  <li>Simple client–server architecture</li>
</ul>

<hr>

<h2>🛠 Technologies Used</h2>
<ul>
  <li>C#</li>
  <li>.NET</li>
  <li>ASP.NET Core Minimal API</li>
  <li>HTTP (REST)</li>
</ul>

</body>
</html>
