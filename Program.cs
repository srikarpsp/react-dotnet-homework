
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Urls.Add("http://localhost:5000");

app.MapGet("/", () => "OK");

app.MapGet("/{cityName}/weather", GetWeatherByCity);

// Cities API
var cities = new List<string> { "New York", "London", "Tokyo", "Grande Prairie" }.Select(city => new Weather(city)).ToList();

app.MapGet("/cities/", () => cities);
app.MapPost("/cities/", async (HttpContext context) =>
{
    var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    var weather = JsonSerializer.Deserialize<Weather>(requestBody, options);
    cities.Add(new Weather(weather.City));
    return Results.Ok("City added successfully.");
});

app.Run();

Weather GetWeatherByCity(string cityName)
{
    app.Logger.LogInformation($"Weather requested for {cityName}.");
    var weather = new Weather(cityName);
    return weather;
}

public record Weather
{
    public string City { get; set; }

    public Weather(string city)
    {
        City = city;
        Conditions = "Cloudy";
        // Temperature here is in celsius degrees, hence the 0-40 range.
        Temperature = new Random().Next(0, 40).ToString();
    }

    public string Conditions { get; set; }
    public string Temperature { get; set; }

    public string Guid { get; set; } = System.Guid.NewGuid().ToString();
}
