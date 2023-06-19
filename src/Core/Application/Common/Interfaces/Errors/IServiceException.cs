using System.Net;

namespace Application.Common.Interfaces.Errors;

public interface IServiceException
{
    HttpStatusCode StatusCode { get; }

    string ErrorMessage { get; }
}