
using CADDD.Domain.Common.Models;

namespace CADDD.Domain.PhysicalDevice.ValueObjects;

public sealed class DeployId : ValueObject
{
    public Guid Value { get; }

    private DeployId(Guid value)
    {
        Value = value;
    }

    public static DeployId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}