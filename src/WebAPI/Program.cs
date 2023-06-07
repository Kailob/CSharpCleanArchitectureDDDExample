using CADDD.Application;
using CADDD.Infrastructure;
using CADDD.WebAPI.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
    builder.Services.AddRouting(options => options.LowercaseUrls = true);
    builder.Services.AddSingleton<ProblemDetailsFactory, WebApiProblemDetailsFactory>();
}

var app = builder.Build();
{
    app.MapGet("/", (HttpContext context) => { return context.Response.WriteAsync($"Web Api"); });
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();    
    app.Run();
}

