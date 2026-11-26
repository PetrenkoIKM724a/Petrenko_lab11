using System.Text.Json;
using lab11.Models;

namespace lab11.Repositories;

public class WeatherRepository
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;
    private readonly string _apiKey;

    public WeatherRepository(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _baseUrl = configuration["OpenWeather:BaseUrl"]
            ?? throw new ArgumentNullException("OpenWeather:BaseUrl is missing");
        _apiKey = configuration["OpenWeather:ApiKey"]
            ?? throw new ArgumentNullException("OpenWeather:ApiKey is missing");
    }

    public async Task<WeatherResponse> GetWeatherAsync(string city)
    {
        var url = $"{_baseUrl}weather?q={Uri.EscapeDataString(city)}&appid={_apiKey}&units=metric&lang=ua";

        var response = await _httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Status: {response.StatusCode}, Message: {content}");
        }

        return JsonSerializer.Deserialize<WeatherResponse>(
            content,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        ) ?? throw new Exception("Не вдалося обробити відповідь від OpenWeatherMap");
    }
}