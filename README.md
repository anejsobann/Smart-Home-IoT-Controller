<h1>💡 SmartHome Light Control (IoT)</h1>

<h2>📘 Application Description</h2>

<p>
<strong>SmartHome Light Control (IoT)</strong> is a beginner-friendly Internet of Things (IoT)
application developed in C#.
The application demonstrates how a smart home device (a light) can be controlled remotely
using a network connection 🌐.
</p>

<p>The project consists of two main components:</p>
<ul>
  <li>🧠 <strong>Backend API</strong> – simulates a smart light device and exposes REST endpoints.</li>
  <li>🌐 <strong>Web Frontend (HTML + CSS)</strong> – provides a browser-based user interface.</li>
</ul>

<p>
The frontend communicates with the backend using <strong>HTTP (REST)</strong>,
which is a common approach in IoT systems 🔌.
</p>

<hr>

<h2>⚙️ Requirements</h2>
<ul>
  <li>.NET SDK (version 7 or higher)</li>
  <li>Web browser (Chrome, Edge, Firefox, Safari)</li>
  <li>Windows, macOS, or Linux</li>
</ul>

<hr>

<h2>📁 Project Structure</h2>

<pre>
SmartHomeProject
│
└── SmartHomeDeviceApi
    ├── Program.cs
    └── wwwroot
        ├── index.html     // Web frontend
        └── style.css      // Styling
</pre>

<hr>

<h2>🧭 Step-by-Step Setup Guide</h2>

<h3>Step 1: Create the Backend API</h3>
<p>Create an ASP.NET Core web project:</p>

<pre>
dotnet new web -n SmartHomeDeviceApi
</pre>

<h3>Step 2: Enable Static Files</h3>
<p>
The backend is configured to serve static HTML and CSS files from the
<code>wwwroot</code> folder.
</p>

<p>Edit the file <code>Program.cs</code>:</p>

<pre>
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Enable serving static HTML and CSS
app.UseDefaultFiles();
app.UseStaticFiles();

// Smart light state (simulation)
bool lightOn = false;

// API endpoints
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

<h3>Step 3: Create the Web Frontend</h3>
<p>
Create a folder named <code>wwwroot</code> inside the API project and add the following files:
</p>

<ul>
  <li><code>index.html</code> – user interface</li>
  <li><code>style.css</code> – styling</li>
</ul>

<p>
The frontend uses JavaScript <code>fetch</code> to communicate with the backend API.
</p>

<h3>Step 4: Run the Application</h3>
<p>Start the backend:</p>

<pre>
dotnet run
</pre>

<p>
The terminal will display the server address, for example:
<code>http://localhost:5213</code>.
</p>

<p>
Open the application in a browser:
</p>

<pre>
http://localhost:9999/
</pre>

<hr>

<h2>🌐 Web Frontend Functionality</h2>

<ul>
  <li>Turn the smart light ON and OFF using buttons</li>
  <li>Display the current light state (ON / OFF)</li>
  <li>Accessible from desktop or mobile browser 📱</li>
</ul>

<hr>

<h2>🔍 How the Application Works</h2>

<ol>
  <li>The backend API simulates a smart light device.</li>
  <li>The web frontend sends HTTP requests to the API.</li>
  <li>The API updates and returns the light state.</li>
  <li>The user controls the device via a browser.</li>
</ol>

<hr>

<h2>✅ Result</h2>

<ul>
  <li>Remote control of a smart home device</li>
  <li>Web-based user interface (HTML + CSS)</li>
  <li>Clear demonstration of IoT communication</li>
  <li>Simple and extensible client–server architecture</li>
</ul>

