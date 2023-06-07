using CADDD.WebAPI.Common.Errors;
using CADDD.WebAPI.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CADDD.WebAPI;

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