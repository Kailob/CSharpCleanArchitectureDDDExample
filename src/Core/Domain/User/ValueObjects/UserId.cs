using Domain.Common.Models;

namespace Domain.User.ValueObjects;

/// <summary>
/// UserID Value Object.
/// </summary>
public sealed class UserId : ValueObject
{
    private UserId(Guid value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets UserID Value.
    /// </summary>
    /// <value>GUID.</value>
    public Guid Value { get; }

    /// <summary>
    /// Create Unique UserID.
    /// </summary>
    /// <returns>UserId.</returns>
    public static UserId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    /// <summary>
    /// Yield return Value.
    /// </summary>
    /// <returns>IEnumerable object.</returns>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
