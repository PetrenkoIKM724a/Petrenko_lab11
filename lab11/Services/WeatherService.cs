using lab11.Repositories;

namespace lab11.Services;

public class WeatherService
{
    private readonly WeatherRepository _weatherRepository;

    public WeatherService(WeatherRepository weatherRepository)
    {
        _weatherRepository = weatherRepository;
    }

    public async Task<string> GetFormattedWeatherAsync(string city)
    {
        var weather = await _weatherRepository.GetWeatherAsync(city);
        var description = weather.Weather.FirstOrDefault()?.Description ?? "немає опису";

        return $"Погода в {weather.Name}: {weather.Main.Temp}°C (відчувається як {weather.Main.FeelsLike}°C), " +
               $"вологість {weather.Main.Humidity}%, {description}.";
    }
}