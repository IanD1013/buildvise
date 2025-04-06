using System.Net;

namespace Weather.Api.Weather;

public class OpenWeatherService : IWeatherService
{
    private const string OpenWeatherApiKey = "f539ebbe9ad5228403f6c267b7b7743c";
    private readonly IHttpClientFactory _httpClientFactory;

    public OpenWeatherService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<WeatherResponse?> GetCurrentWeatherAsync(string city)
    {
        var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={OpenWeatherApiKey}&units=metric";
        var httpClient = _httpClientFactory.CreateClient();

        var weatherResponse = await httpClient.GetAsync(url);
        if (weatherResponse.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }
        var weather = await weatherResponse.Content.ReadFromJsonAsync<WeatherResponse>();
        return weather;
    }
}
