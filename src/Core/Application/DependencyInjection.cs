using Application.Authentication.Commands.Register;
using Application.Authentication.Common;
using Application.Common.Behaviors;

using ErrorOr;

using FluentValidation;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace Application;

/// <summary>
/// Application Layer Dependency Injection.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Add Application services.
    /// </summary>
    /// <param name="services">IServiceCollection.</param>
    /// <returns>services.</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));
        services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();
        return services;
    }
}
