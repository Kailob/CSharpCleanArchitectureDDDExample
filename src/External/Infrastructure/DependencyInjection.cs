using CADDD.Application.Common.Interfaces.Authentication;
using CADDD.Application.Common.Interfaces.Persistence;
using CADDD.Application.Common.Interfaces.Services;
using CADDD.Infrastructure.Authentication;
using CADDD.Infrastructure.Persistence;
using CADDD.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CADDD.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    ) 
    {
        services.ConfigureOptions<JwtSettingsSetup>();
        //services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.AddSingleton<IJwTokenGenerator, JwTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}