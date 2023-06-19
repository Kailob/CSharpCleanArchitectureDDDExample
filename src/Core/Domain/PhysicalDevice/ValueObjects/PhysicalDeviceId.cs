using Domain.Common.Models;

namespace Domain.PhysicalDevice.ValueObjects;

/// <summary>
/// Physical DeviceId value object.
/// </summary>
public sealed class PhysicalDeviceId : ValueObject
{
    private PhysicalDeviceId(Guid value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets value.
    /// </summary>
    /// <value>Guid.</value>
    public Guid Value { get; }

    /// <summary>
    /// Create Unique PhysicalDeviceId.
    /// </summary>
    /// <returns>PhysicalDeviceId instance.</returns>
    public static PhysicalDeviceId CreateUnique() => new(Guid.NewGuid());

    /// <summary>
    /// Returns PhysicalDeviceId equality components.
    /// </summary>
    /// <returns>IEnumerable object.</returns>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
