using Domain.Common.Models;

namespace Domain.DeviceAggregate.ValueObjects;

/// <summary>
/// SoftwareId Value Object.
/// </summary>
public sealed class SoftwareId : ValueObject
{
    private SoftwareId(Guid value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets value.
    /// </summary>
    /// <value>Guid.</value>
    public Guid Value { get; }

    /// <summary>
    /// Create SoftwareId.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>SoftwareId instance.</returns>
    public static SoftwareId Create(Guid value) => new(value);

    /// <summary>
    /// Create Unique SoftwareId.
    /// </summary>
    /// <returns>SoftwareId instance.</returns>
    public static SoftwareId CreateUnique() => new(Guid.NewGuid());

    /// <summary>
    /// Returns TenantId equality components.
    /// </summary>
    /// <returns>IEnumerable object.</returns>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
