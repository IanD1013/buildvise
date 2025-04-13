namespace MultiFunction.ConsoleApp.Weather;

public interface IWeatherService
{
    Task<WeatherResponse?> GetCurrentWeatherAsync(string city);
}
