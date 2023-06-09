
using CADDD.Domain.Common.Models;

namespace CADDD.Domain.PhysicalDevice.ValueObjects;

public sealed class DeviceModuleId : ValueObject
{
    public Guid Value { get; }

    private DeviceModuleId(Guid value)
    {
        Value = value;
    }

    public static DeviceModuleId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}