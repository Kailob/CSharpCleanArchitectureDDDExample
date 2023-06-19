using Domain.Common.Models;

namespace Domain.PhysicalDevice.ValueObjects;

/// <summary>
/// MetaDataId Id value object.
/// </summary>
public sealed class MetaDataId : ValueObject
{
    private MetaDataId(Guid value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets value.
    /// </summary>
    /// <value>Guid.</value>
    public Guid Value { get; }

    /// <summary>
    /// Create Unique MetaDataId.
    /// </summary>
    /// <returns>MetaDataId instance.</returns>
    public static MetaDataId CreateUnique() => new(Guid.NewGuid());

    /// <summary>
    /// Returns MetaDataId equality components.
    /// </summary>
    /// <returns>IEnumerable object.</returns>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
