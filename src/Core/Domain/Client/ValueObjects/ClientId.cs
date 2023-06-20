using Domain.Common.Models;

namespace Domain.Client.ValueObjects;

/// <summary>
/// ClientId Value Object.
/// </summary>
public sealed class ClientId : ValueObject
{
    private ClientId(Guid value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets value.
    /// </summary>
    /// <value>Guid.</value>
    public Guid Value { get; }

    /// <summary>
    /// Create Unique ClientId.
    /// </summary>
    /// <returns>ClientId instance.</returns>
    public static ClientId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    /// <summary>
    /// Returns ClientId equality components.
    /// </summary>
    /// <returns>IEnumerable object.</returns>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
