namespace Weather.Api.Weather;

public class   InMemoryWeatherService : IWeatherService
{
    public Task<WeatherModel?> GetCurrentWeatherAsync(string city)
    {
        return Task.FromResult(new WeatherModel
        {
            Coord = new Coord
            {
                Lat = -0.1257,
                Lon = 51.5085
            },
            Weather = new List<Weather>
            {
                new Weather
                {
                    Id = 803,
                    Description = "broken clouds",
                    Icon = "04n"
                }
            },
            Base = "stations",
            Main = new Main
            {
                Temp = 7.65,
                FeelsLike = 5.05,
                TempMin = 6.18,
                TempMax = 9.03,
                Pressure = 991,
                Humidity = 93
            },
            Visibility = 5000,
            Wind = new Wind
            {
                Speed = 4.12,
                Deg = 140
            },
            Clouds = new Clouds
            {
                All = 75
            },
            Dt = 1639086895,
            Sys = new Sys
            {
                Type = 2,
                Id = 2019646,
                Country = "GB",
                Sunrise = 1639036450,
                Sunset = 1639065114
            },
            Timezone = 0,
            Id = 2643743,
            Name = "London",
            Cod = 200
        })!;
    }
}
