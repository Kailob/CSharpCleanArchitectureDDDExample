
using CADDD.Domain.Common.Models;

namespace CADDD.Domain.PhysicalDevice.ValueObjects;

public sealed class IoTHubDeviceId : ValueObject
{
    public Guid Value { get; }

    private IoTHubDeviceId(Guid value)
    {
        Value = value;
    }

    public static IoTHubDeviceId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}