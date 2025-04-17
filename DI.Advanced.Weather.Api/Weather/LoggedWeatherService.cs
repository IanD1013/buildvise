using System.Diagnostics;
using Weather.Api.Logging;

namespace Weather.Api.Weather;

public class LoggedWeatherService : IWeatherService
{
    private readonly IWeatherService _weatherService;
    private readonly ILoggerAdapter<IWeatherService> _logger;

    public LoggedWeatherService(IWeatherService weatherService, ILoggerAdapter<IWeatherService> logger)
    {
        _weatherService = weatherService;
        _logger = logger;
    }

    public async Task<WeatherResponse?> GetCurrentWeatherAsync(string city)
    {
        using var _ = _logger.TimedOperation("Weather retrieval for city: {0},", city);
        return await _weatherService.GetCurrentWeatherAsync(city);
    }
}
