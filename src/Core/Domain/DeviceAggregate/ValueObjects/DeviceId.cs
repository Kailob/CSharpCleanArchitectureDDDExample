using Domain.Common.Models;

namespace Domain.DeviceAggregate.ValueObjects;

/// <summary>
/// Physical DeviceId value object.
/// </summary>
public sealed class DeviceId : ValueObject
{
    private DeviceId(Guid value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets value.
    /// </summary>
    /// <value>Guid.</value>
    public Guid Value { get; }

    /// <summary>
    /// Create Unique DeviceId.
    /// </summary>
    /// <returns>DeviceId instance.</returns>
    public static DeviceId CreateUnique() => new(Guid.NewGuid());

    /// <summary>
    /// Returns DeviceId equality components.
    /// </summary>
    /// <returns>IEnumerable object.</returns>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
