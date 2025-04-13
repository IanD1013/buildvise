using Microsoft.Extensions.DependencyInjection;
using MultiFunction.ConsoleApp;
using MultiFunction.ConsoleApp.Console;
using MultiFunction.ConsoleApp.Handlers;
using MultiFunction.ConsoleApp.Time;
using MultiFunction.ConsoleApp.Weather;

var services = new ServiceCollection();

services.AddSingleton<IConsoleWriter, ConsoleWriter>();
services.AddHttpClient();
services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
services.AddSingleton<IWeatherService, OpenWeatherService>();

services.AddCommandHandlers(typeof(Program).Assembly);

services.AddSingleton<Application>();

var serviceProvider = services.BuildServiceProvider();

var application = serviceProvider.GetRequiredService<Application>();
if (args.Length == 0)
{
    args = new[] { "weather" };
}

await application.RunAsync(args);
