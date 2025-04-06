using Weather.Api.Weather;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class WeatherServiceRegistration
{
    public static IServiceCollection AddWeatherServices(this IServiceCollection services)
    {
        // services.AddTransient<IWeatherService, OpenWeatherService>();
        // services.AddTransient<IWeatherService, InMemoryWeatherService>();

        var openWeatherServiceDescriptor =
            new ServiceDescriptor(typeof(IWeatherService), typeof(OpenWeatherService), ServiceLifetime.Transient);

        var inMemWeatherServiceDescriptor =
            new ServiceDescriptor(typeof(IWeatherService), typeof(InMemoryWeatherService), ServiceLifetime.Transient);

        services.Add(openWeatherServiceDescriptor);
        services.Add(inMemWeatherServiceDescriptor);
        return services;
    }
}
