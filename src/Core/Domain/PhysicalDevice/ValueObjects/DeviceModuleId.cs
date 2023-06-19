using Domain.Common.Models;

namespace Domain.PhysicalDevice.ValueObjects;

/// <summary>
/// DeviceModuleId Value Object.
/// </summary>
public sealed class DeviceModuleId : ValueObject
{
    private DeviceModuleId(Guid value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets value.
    /// </summary>
    /// <value>Guid.</value>
    public Guid Value { get; }

    /// <summary>
    /// Create Unique DeviceModuleId.
    /// </summary>
    /// <returns>DeviceModuleId instance.</returns>
    public static DeviceModuleId CreateUnique() => new(Guid.NewGuid());

    /// <summary>
    /// Returns DeviceModuleId equality components.
    /// </summary>
    /// <returns>IEnumerable object.</returns>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
