using System.Text;
using Buildvise.Application.Common.Interfaces;
using Buildvise.Domain.Common.Interfaces;
using Buildvise.Infrastructure.Authentication.PasswordHasher;
using Buildvise.Infrastructure.Authentication.TokenGenerator;
using Buildvise.Infrastructure.Clients.Persistence;
using Buildvise.Infrastructure.Common.Persistence;
using Buildvise.Infrastructure.Companies.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Buildvise.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddPersistence(configuration)
            .AddAuthentication(configuration);
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default") 
                               ?? throw new InvalidOperationException("Db Connection string not found!");
        services.AddDbContext<BuildviseDbContext>(optionsBuilder =>
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });

        services.AddScoped<IClientsRepository, ClientsRepository>();
        services.AddScoped<ICompaniesRepository, CompaniesRepository>();
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<BuildviseDbContext>());
        
        return services;
    }

    private static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.Section, jwtSettings); 
        
        services.AddSingleton(Options.Create(jwtSettings)); 
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IPasswordHasher, PasswordHasher>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
            });

        return services;
    }
}