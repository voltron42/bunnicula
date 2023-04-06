public class Program {
    public static async Task Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.Urls.Add("http://localhost:5000");

        app.MapGet("/", () => "Hello World!");

        app.MapGet("/{cityName}/weather", (string cityName) => GetWeatherByCity(app, cityName));

        app.Run();
    }
 
    public static Weather GetWeatherByCity(WebApplication app, string cityName)
    {
        app.Logger.LogInformation($"Weather requested for {cityName}.");
        var weather = new Weather(cityName);
        return weather;
    }
}

public record Weather
{
    public string City { get; set; }

    public Weather(string city)
    {
        City = city;
        Conditions = "Cloudy";
        // Temperature here is in celsius degrees, hence the 0-40 range.
        Temperature = new Random().Next(0,40).ToString();
    }

    public string Conditions { get; set; }
    public string Temperature { get; set; }
}