using Domain.Common.Models;

namespace Domain.StoreAggregate.ValueObjects;

/// <summary>
/// Store Id value object.
/// </summary>
public sealed class StoreId : ValueObject
{
    private StoreId(Guid value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets value.
    /// </summary>
    /// <value>Guid.</value>
    public Guid Value { get; }

    /// <summary>
    /// Create StoreId.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>StoreId instance.</returns>
    public static StoreId Create(Guid value) => new(value);

    /// <summary>
    /// Create Unique StoreId.
    /// </summary>
    /// <returns>StoreId instance.</returns>
    public static StoreId CreateUnique() => new(Guid.NewGuid());

    /// <summary>
    /// Returns Store Id equality components.
    /// </summary>
    /// <returns>IEnumerable object.</returns>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
