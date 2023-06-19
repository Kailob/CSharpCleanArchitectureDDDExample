using WebAPI.Common.Errors;
using WebAPI.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace WebAPI;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMappings();
        services.AddControllers();
        services.AddRouting(options => options.LowercaseUrls = true);
        services.AddSingleton<ProblemDetailsFactory, WebApiProblemDetailsFactory>();

        return services;
    }
}