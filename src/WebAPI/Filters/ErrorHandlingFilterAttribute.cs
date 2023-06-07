using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace CADDD.WebAPI.Filters;

public class ErrorHandlingFilterAttribute: ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        //var errorResult = new { error = "Error occurred while processing your request." };
        //context.Result = new ObjectResult(errorResult)
        //{
        //    StatusCode = 500
        //};
        var problemDetails = new ProblemDetails 
        { 
            Title = "Error occurred while processing your request.",
            Status = (int) HttpStatusCode.InternalServerError,
            //Instance = context.HttpContext.Request.Path,
            //Detail = exception.Message
        };
        context.Result = new ObjectResult(problemDetails);
        context.ExceptionHandled = true;
    }
}
