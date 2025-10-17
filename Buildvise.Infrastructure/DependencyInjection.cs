using Buildvise.Application.Common.Interfaces;
using Buildvise.Infrastructure.Common.Persistence;
using Buildvise.Infrastructure.Companies.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Buildvise.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<BuildviseDbContext>(optionsBuilder =>
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });
        
        services.AddScoped<ICompaniesRepository, CompaniesRepository>();
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<BuildviseDbContext>());
        
        return services;
    }
}