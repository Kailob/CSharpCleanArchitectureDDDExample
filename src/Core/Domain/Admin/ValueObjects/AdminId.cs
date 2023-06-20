using Domain.Common.Models;

namespace Domain.Admin.ValueObjects;

/// <summary>
/// AdminId Value Object.
/// </summary>
public sealed class AdminId : ValueObject
{
    private AdminId(Guid value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets value.
    /// </summary>
    /// <value>Guid.</value>
    public Guid Value { get; }

    /// <summary>
    /// Create Unique AdminId.
    /// </summary>
    /// <returns>AdminId instance.</returns>
    public static AdminId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    /// <summary>
    /// Returns AdminId equality components.
    /// </summary>
    /// <returns>IEnumerable object.</returns>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
