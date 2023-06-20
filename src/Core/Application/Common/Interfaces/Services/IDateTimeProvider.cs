namespace Application.Common.Interfaces.Services;

/// <summary>
/// interface for DateTime Provider.
/// </summary>
public interface IDateTimeProvider
{
    /// <summary>
    /// Gets UtcNow.
    /// </summary>
    /// <value>DateTime.</value>
    DateTime UtcNow { get; }
}
