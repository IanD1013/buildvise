using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Weather.Api.Weather;

public class LoggedWeatherService : IWeatherService
{
    private readonly IWeatherService _weatherService; //<-- OpenWeatherService
    private readonly ILogger<IWeatherService> _logger;

    public LoggedWeatherService(IWeatherService weatherService, ILogger<IWeatherService> logger)
    {
        _weatherService = weatherService;
        _logger = logger;
    }

    public async Task<WeatherResponse?> GetCurrentWeatherAsync(string city)
    {
        var sw = Stopwatch.StartNew();
        try
        {
            return await _weatherService.GetCurrentWeatherAsync(city);
        }
        finally
        {
            sw.Stop();
            _logger.LogInformation("Weather retrieval for city: {0}, took {1}ms",
                city, sw.ElapsedMilliseconds);
        }
    }
}
