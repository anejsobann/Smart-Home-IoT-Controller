var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Stanje "pametne luči" (simulacija naprave)
bool lightOn = false;

// Vrni stanje
app.MapGet("/api/light/state", () => Results.Ok(new { on = lightOn }));

// Prižgi
app.MapPost("/api/light/on", () =>
{
    lightOn = true;
    return Results.Ok(new { on = lightOn });
});

// Ugasni
app.MapPost("/api/light/off", () =>
{
    lightOn = false;
    return Results.Ok(new { on = lightOn });
});

app.Run();
