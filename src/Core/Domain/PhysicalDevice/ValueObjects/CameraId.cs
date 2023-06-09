
using CADDD.Domain.Common.Models;

namespace CADDD.Domain.PhysicalDevice.ValueObjects;

public sealed class CameraId : ValueObject
{
    public Guid Value { get; }

    private CameraId(Guid value)
    {
        Value = value;
    }

    public static CameraId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}