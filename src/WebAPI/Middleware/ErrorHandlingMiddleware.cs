using Newtonsoft.Json;
using System.Net;

namespace CADDD.WebAPI.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly IMiddleware _middleware;
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context) 
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex) 
        {
            await HandleExceptionAsync(context);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int) HttpStatusCode.InternalServerError; // 500
        var result = JsonConvert.SerializeObject(new { error = "Error occurred while processing your request." });
        return context.Response.WriteAsync(result);
    }
}
