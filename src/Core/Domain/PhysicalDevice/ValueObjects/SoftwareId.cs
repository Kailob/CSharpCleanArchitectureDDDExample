
using CADDD.Domain.Common.Models;

namespace CADDD.Domain.PhysicalDevice.ValueObjects;

public sealed class SoftwareId : ValueObject
{
    public Guid Value { get; }

    private SoftwareId(Guid value)
    {
        Value = value;
    }

    public static SoftwareId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}