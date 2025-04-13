using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MultiFunction.ConsoleApp.Handlers;

public class HandlerOrchestrator
{
    private readonly Dictionary<string, Type> _handlerTypes = new();
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public HandlerOrchestrator(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
        RegisterCommandHandler();
    }

    public IHandler? GetHandlerForCommandName(string command)
    {
        var handlerType = _handlerTypes.GetValueOrDefault(command);

        if (handlerType is null)
        {
            return null;
        }

        using var serviceScope = _serviceScopeFactory.CreateScope();
        return (IHandler)serviceScope.ServiceProvider.GetRequiredService(handlerType);
    }

    private void RegisterCommandHandler()
    {
        var handlerTypes = HandlerExtensions.GetHandlerTypesForAssembly(typeof(IHandler).Assembly);

        foreach (var handlerType in handlerTypes)
        {
            var commandNameAttribute = handlerType.GetCustomAttribute<CommandNameAttribute>();
            if (commandNameAttribute is null)
            {
                continue;
            }

            var commandName = commandNameAttribute.CommandName;
            _handlerTypes[commandName] = handlerType;
        }
    }
}
