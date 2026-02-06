<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <title>SmartHome Light Control (IoT) - README</title>
  <style>
    :root { color-scheme: light dark; }
    body {
      font-family: system-ui, -apple-system, Segoe UI, Roboto, Arial, sans-serif;
      line-height: 1.6;
      margin: 0;
      padding: 32px;
      max-width: 980px;
      margin-inline: auto;
    }
    header {
      padding: 18px 20px;
      border: 1px solid #ccc;
      border-radius: 14px;
      margin-bottom: 22px;
    }
    h1 { margin: 0; font-size: 2rem; }
    h2 { margin-top: 28px; }
    h3 { margin-top: 20px; }
    p { margin: 10px 0; }
    .badge {
      display: inline-block;
      padding: 4px 10px;
      border-radius: 999px;
      border: 1px solid #aaa;
      font-size: 0.9rem;
      margin-right: 8px;
      margin-top: 10px;
    }
    ul, ol { padding-left: 20px; }
    pre {
      padding: 14px;
      border-radius: 12px;
      overflow: auto;
      border: 1px solid #aaa;
    }
    code { font-family: ui-monospace, SFMono-Regular, Menlo, Consolas, monospace; }
    .callout {
      border-left: 5px solid #888;
      padding: 12px 14px;
      background: rgba(127,127,127,0.08);
      border-radius: 10px;
      margin: 12px 0;
    }
    .tree {
      padding: 14px;
      border-radius: 12px;
      border: 1px dashed #aaa;
      white-space: pre;
      overflow: auto;
    }
    footer {
      margin-top: 36px;
      font-size: 0.95rem;
      opacity: 0.9;
    }
  </style>
</head>
<body>

  <header>
    <h1>💡 SmartHome Light Control (IoT)</h1>
    <div>
      <span class="badge">C#</span>
      <span class="badge">.NET</span>
      <span class="badge">ASP.NET Core Minimal API</span>
      <span class="badge">HTTP (REST)</span>
    </div>
  </header>

  <section>
    <h2>📘 Application Description</h2>
    <p><strong>SmartHome Light Control (IoT)</strong> is a beginner-friendly Internet of Things (IoT) application developed in C#.
      The application demonstrates how a smart home device (a light) can be controlled remotely using a network connection 🌐.</p>

    <p>The project is split into two simple parts:</p>
    <ol>
      <li>🧠 <strong>Backend API</strong> – simulates a smart light device.</li>
      <li>💻 <strong>Console Client</strong> – allows the user to control the light from the terminal.</li>
    </ol>

    <p>The client communicates with the device using <strong>HTTP REST requests</strong>, a common approach in IoT and smart home systems 🔌.</p>
  </section>

  <section>
    <h2>⚙️ Requirements</h2>
    <ul>
      <li>.NET SDK installed (version 7 or higher)</li>
      <li>Terminal / Command Line</li>
      <li>Any operating system (Windows, macOS, Linux)</li>
    </ul>
  </section>

  <section>
    <h2>📁 Project Structure</h2>
    <div class="tree">SmartHomeProject
│
├── SmartHomeDeviceApi      // Backend (smart device simulation)
└── SmartHomeConsoleApp     // Console client (user interface)</div>
  </section>

  <section>
    <h2>🧭 Step-by-Step Setup Guide</h2>

    <h3>🟢 Step 1: Create the Solution</h3>
    <p>Open a terminal and navigate to the folder where you want to store the project.</p>
    <pre><code>mkdir SmartHomeProject
cd SmartHomeProject
dotnet new sln -n SmartHomeProject</code></pre>

    <h3>🟢 Step 2: Create the Backend API (Smart Device)</h3>
    <p>Create an ASP.NET Core web project:</p>
    <pre><code>dotnet new web -n SmartHomeDeviceApi
dotnet sln SmartHomeProject.sln add SmartHomeDeviceApi/SmartHomeDeviceApi.csproj</code></pre>

    <h3>🟢 Step 3: Implement the Backend Logic</h3>
    <p>Open the file:</p>
    <pre><code>SmartHomeDeviceApi/Program.cs</code></pre>
    <p>Replace its contents with:</p>
    <pre><code>var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

bool lightOn = false;

app.MapGet("/api/light/state", () =&gt; Results.Ok(new { on = lightOn }));

app.MapPost("/api/light/on", () =&gt;
{
    lightOn = true;
    return Results.Ok(new { on = lightOn });
});

app.MapPost("/api/light/off", () =&gt;
{
    lightOn = false;
    return Results.Ok(new { on = lightOn });
});

app.Run();</code></pre>

    <h3>🟢 Step 4: Run the Backend 🚀</h3>
    <p>Start the backend API:</p>
    <pre><code>cd SmartHomeDeviceApi
dotnet run</code></pre>

    <div class="callout">
      ⚠️ <strong>Important:</strong> You will see output similar to:
      <pre><code>Now listening on: http://localhost:5213</code></pre>
      Write down the port number (e.g. <code>5213</code>). The backend must remain running.
    </div>

    <h3>🟢 Step 5: Create the Console Client 💻</h3>
    <p>Open a new terminal window and navigate back to the project root:</p>
    <pre><code>cd ../
dotnet new console -n SmartHomeConsoleApp
dotnet sln SmartHomeProject.sln add SmartHomeConsoleApp/SmartHomeConsoleApp.csproj</code></pre>

    <h3>🟢 Step 6: Implement the Console Client</h3>
    <p>Open the file:</p>
    <pre><code>SmartHomeConsoleApp/Program.cs</code></pre>
    <p>Replace its contents with:</p>
    <pre><code>using System.Net.Http.Json;

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
            var state = await http.GetFromJsonAsync&lt;LightState&gt;($"{BaseUrl}/api/light/state");
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
}</code></pre>

    <h3>🟢 Step 7: Run the Console Client ▶️</h3>
    <pre><code>cd SmartHomeConsoleApp
dotnet run</code></pre>
  </section>

  <section>
    <h2>🔍 How the Application Works</h2>
    <ol>
      <li>The backend API simulates a smart light device 💡.</li>
      <li>The console client sends HTTP requests 📡.</li>
      <li>The backend updates and returns the current light state.</li>
      <li>The user can remotely control and monitor the device 🏠.</li>
    </ol>
  </section>

  <section>
    <h2>✅ Result</h2>
    <ul>
      <li>Remote control of a smart home device</li>
      <li>Clear demonstration of IoT communication</li>
      <li>Simple and understandable client–server architecture</li>
    </ul>
  </section>

  <section>
    <h2>🛠 Technologies Used</h2>
    <ul>
      <li>C#</li>
      <li>.NET</li>
      <li>ASP.NET Core Minimal API</li>
      <li>HTTP (REST)</li>
    </ul>
  </section>

  <footer>
    <p>✨ Tip: Keep the backend running while using the console client. Use <strong>Ctrl + C</strong> to stop the backend when finished.</p>
  </footer>

</body>
</html>
