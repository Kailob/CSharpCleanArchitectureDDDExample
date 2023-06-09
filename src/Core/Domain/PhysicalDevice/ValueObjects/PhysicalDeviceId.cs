
using CADDD.Domain.Common.Models;

namespace CADDD.Domain.PhysicalDevice.ValueObjects;

public sealed class PhysicalDeviceId : ValueObject
{
    public Guid Value { get; }

    private PhysicalDeviceId(Guid value)
    {
        Value = value;
    }

    public static PhysicalDeviceId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}