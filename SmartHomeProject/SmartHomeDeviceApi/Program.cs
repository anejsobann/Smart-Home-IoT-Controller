var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

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