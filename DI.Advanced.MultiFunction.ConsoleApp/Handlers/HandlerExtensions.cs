using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MultiFunction.ConsoleApp.Handlers;

public static class HandlerExtensions
{
    public static void AddCommandHandlers(this IServiceCollection services, Assembly assembly)
    {
        services.TryAddSingleton<HandlerOrchestrator>();

        var handlerTypes = GetHandlerTypesForAssembly(assembly);

        foreach (var handlerType in handlerTypes)
        {
            services.TryAddTransient(handlerType);
        }
    }

    public static IEnumerable<TypeInfo> GetHandlerTypesForAssembly(Assembly assembly)
    {
        var handlerTypes = assembly.DefinedTypes
            .Where(x => !x.IsInterface && !x.IsAbstract && typeof(IHandler).IsAssignableFrom(x));
        return handlerTypes;
    }
}
