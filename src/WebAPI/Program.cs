using CADDD.Application;
using CADDD.Infrastructure;
using CADDD.WebAPI.Errors;
using CADDD.WebAPI.Filters;
using CADDD.WebAPI.Middleware;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
    //builder.Services.AddControllers(
    //    options => options.Filters.Add<ErrorHandlingFilterAttribute>()
    //);

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    // builder.Services.AddEndpointsApiExplorer();
    // builder.Services.AddSwaggerGen();
    builder.Services.AddRouting(options => options.LowercaseUrls = true);

    builder.Services.AddSingleton<ProblemDetailsFactory, WebApiProblemDetailsFactory>();
}

var app = builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");

    // // Configure the HTTP request pipeline.
    // if (app.Environment.IsDevelopment())
    // {
    //     app.UseSwagger();
    //     app.UseSwaggerUI();
    // }

    app.UseHttpsRedirection();
    // app.UseAuthorization();
    app.MapControllers();

    app.MapGet("/", (HttpContext context) => {
        return context.Response.WriteAsync($"Web Api");
    });

    app.MapGet("/error", (HttpContext context) => {
        var exception = context.Features.Get<IExceptionHandlerFeature>();
        return Results.Problem();
    });

    app.Run();
}

