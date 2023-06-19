using Domain.Common.Models;

namespace Domain.PhysicalDevice.ValueObjects;

/// <summary>
/// IoTDeviceId Value Object.
/// </summary>
public sealed class IoTDeviceId : ValueObject
{
    private IoTDeviceId(Guid value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets value.
    /// </summary>
    /// <value>Guid.</value>
    public Guid Value { get; }

    /// <summary>
    /// Create Unique IoTDeviceId.
    /// </summary>
    /// <returns>IoTDeviceId instance.</returns>
    public static IoTDeviceId CreateUnique() => new(Guid.NewGuid());

    /// <summary>
    /// Returns IoTDeviceId equality components.
    /// </summary>
    /// <returns>IEnumerable object.</returns>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
