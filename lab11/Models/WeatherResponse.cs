using System.Text.Json.Serialization;

namespace lab11.Models;

public class WeatherResponse
{
    public string Name { get; set; } = string.Empty;
    public MainInfo Main { get; set; } = new();
    public List<WeatherDescription> Weather { get; set; } = new();
}

public class MainInfo
{
    public double Temp { get; set; }

    [JsonPropertyName("feels_like")]
    public double FeelsLike { get; set; }

    public int Humidity { get; set; }
}

public class WeatherDescription
{
    public string Description { get; set; } = string.Empty;
}