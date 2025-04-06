using Microsoft.Extensions.DependencyInjection;
using Weather.ConsoleApp;
using Weather.ConsoleApp.Weather;

if (args.Length == 0)
{
    args = new string[1];
    args[0] = "London";
}

var services = new ServiceCollection(); // from nuget package 

services.AddSingleton<IWeatherService, OpenWeatherService>();
//services.AddSingleton<Application>();

var serviceProvider = services.BuildServiceProvider(); // build service provider, is a container

var app = serviceProvider.GetService<Application>();
var application = serviceProvider.GetRequiredService<Application>();

await application.RunAsync(args);
