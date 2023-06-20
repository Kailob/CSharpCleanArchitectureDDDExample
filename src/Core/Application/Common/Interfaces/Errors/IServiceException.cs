using System.Net;

namespace Application.Common.Interfaces.Errors;

/// <summary>
/// Interface for service exceptions.
/// </summary>
public interface IServiceException
{
    /// <summary>
    /// Gets hTTP Status Code.
    /// </summary>
    /// <value>HttpStatusCode.</value>
    HttpStatusCode StatusCode { get; }

    /// <summary>
    /// Gets error Message.
    /// </summary>
    /// <value>string.</value>
    string ErrorMessage { get; }
}
