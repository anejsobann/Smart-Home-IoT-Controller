using System.Net.Http.Json;

const string BaseUrl = "http://localhost:5213";
 // <-- tukaj popravi port, če ni 5000

using var http = new HttpClient();

while (true)
{
    Console.WriteLine("\n=== PAMETNA LUČ (IoT) ===");
    Console.WriteLine("1 - Prižgi (ON)");
    Console.WriteLine("2 - Ugasni (OFF)");
    Console.WriteLine("3 - Prikaži stanje");
    Console.WriteLine("0 - Izhod");
    Console.Write("Izbira: ");

    var choice = Console.ReadLine();

    try
    {
        if (choice == "1")
        {
            await http.PostAsync($"{BaseUrl}/api/light/on", null);
            Console.WriteLine("OK: Luč prižgana.");
        }
        else if (choice == "2")
        {
            await http.PostAsync($"{BaseUrl}/api/light/off", null);
            Console.WriteLine("OK: Luč ugasnjena.");
        }
        else if (choice == "3")
        {
            var state = await http.GetFromJsonAsync<LightState>($"{BaseUrl}/api/light/state");
            Console.WriteLine($"Stanje: {(state?.on == true ? "ON" : "OFF")}");
        }
        else if (choice == "0")
        {
            Console.WriteLine("Izhod...");
            break;
        }
        else
        {
            Console.WriteLine("Neveljavna izbira.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Napaka pri povezavi na API!");
        Console.WriteLine(ex.Message);
        Console.WriteLine("Preveri, če backend teče in če je BaseUrl pravilen.");
    }
}

public class LightState
{
    public bool on { get; set; }
}
