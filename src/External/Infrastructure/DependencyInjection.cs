using CADDD.Application.Common.Interfaces.Authentication;
using CADDD.Application.Common.Interfaces.Persistence;
using CADDD.Application.Common.Interfaces.Services;
using CADDD.Infrastructure.Authentication;
using CADDD.Infrastructure.Persistence;
using CADDD.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CADDD.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    ) 
    {
        services.AddAuth( configuration );
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    public static IServiceCollection AddAuth(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        JwtSettings JwtSettings = new JwtSettings();
        configuration
            .GetSection(nameof(JwtSettings))
            .Bind(JwtSettings);
        ////services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        //services.ConfigureOptions<JwtSettingsSetup>();
        services.AddSingleton(Options.Create(JwtSettings));

        services.AddSingleton<IJwTokenGenerator, JwTokenGenerator>();
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt => opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = JwtSettings.Issuer,
                ValidAudience = JwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(JwtSettings.Secret)
                ),
            });

        return services;
    }
}