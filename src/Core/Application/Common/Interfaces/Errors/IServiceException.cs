using System.Net;

namespace CADDD.Application.Common.Interfaces.Errors;

public interface IServiceException
{
    HttpStatusCode StatusCode { get; }
    string ErrorMessage { get; }
}
