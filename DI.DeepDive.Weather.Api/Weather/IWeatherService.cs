namespace Weather.Api.Weather;

public interface IWeatherService
{
    Task<WeatherModel?> GetCurrentWeatherAsync(string city);
}
