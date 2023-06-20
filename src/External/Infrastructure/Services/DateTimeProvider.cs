using Application.Common.Interfaces.Services;

namespace Infrastructure.Services;

/// <summary>
/// DateTime Provider. IDateTimeProvider implementation.
/// </summary>
public class DateTimeProvider
: IDateTimeProvider
{
    /// <summary>
    /// Gets UtcNow.
    /// </summary>
    /// <value>DateTime.</value>
    public DateTime UtcNow => DateTime.UtcNow;
}
