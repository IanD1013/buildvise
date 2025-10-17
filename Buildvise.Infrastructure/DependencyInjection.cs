using Buildvise.Application.Common.Interfaces;
using Buildvise.Infrastructure.Companies.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Buildvise.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ICompaniesRepository, CompaniesRepository>();
        
        return services;
    }
}