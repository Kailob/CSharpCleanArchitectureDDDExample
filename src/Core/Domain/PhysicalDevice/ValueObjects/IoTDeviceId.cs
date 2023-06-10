
using CADDD.Domain.Common.Models;

namespace CADDD.Domain.PhysicalDevice.ValueObjects;

public sealed class IoTDeviceId : ValueObject
{
    public Guid Value { get; }

    private IoTDeviceId(Guid value)
    {
        Value = value;
    }

    public static IoTDeviceId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}