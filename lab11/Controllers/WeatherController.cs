using Microsoft.AspNetCore.Mvc;
using lab11.Services;

namespace lab11.Controllers;

[ApiController]
[Route("api/weather")]
public class WeatherController : ControllerBase
{
    private readonly WeatherService _weatherService;

    public WeatherController(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet("{city}")]
    public async Task<IActionResult> GetWeather(string city)
    {
        try
        {
            var result = await _weatherService.GetFormattedWeatherAsync(city);
            return Ok(new { message = result });
        }
        catch (HttpRequestException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
}