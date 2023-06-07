using CADDD.Application;
using CADDD.Infrastructure;
using CADDD.WebAPI;
using CADDD.WebAPI.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration)
        .AddPresentation();
}

var app = builder.Build();
{
    app.MapGet("/", (HttpContext context) => { return context.Response.WriteAsync($"Web Api"); });
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();    
    app.Run();
}

