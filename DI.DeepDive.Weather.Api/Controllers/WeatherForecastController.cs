using Microsoft.AspNetCore.Mvc;
using Weather.Api.Logging;
using Weather.Api.Mappers;
using Weather.Api.Weather;

namespace Weather.Api.Controllers;

[ApiController]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherService _weatherService;
    //private readonly IMapper _mapper;
    private readonly ILoggerAdapter<WeatherForecastController> _logger;

    public WeatherForecastController(IWeatherService weatherService,
        ILoggerAdapter<WeatherForecastController> logger /*, IMapper mapper*/)
    {
        _weatherService = weatherService;
        _logger = logger;
        //_mapper = mapper;
    }

    [HttpGet("weather/{city}")]
    public async Task<IActionResult> GetCurrentWeather([FromRoute] string city)
    {
        var weather = await _weatherService.GetCurrentWeatherAsync(city);
        if (weather == null)
        {
            return NotFound();
        }

        var weatherResponse = weather.MapToWeatherResponse();
        //var weatherResponse = _mapper.MapToWeatherResponse(weather);
        return Ok(weatherResponse);
    }
}
