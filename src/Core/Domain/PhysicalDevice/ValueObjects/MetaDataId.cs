
using CADDD.Domain.Common.Models;

namespace CADDD.Domain.PhysicalDevice.ValueObjects;

public sealed class MetaDataId : ValueObject
{
    public Guid Value { get; }

    private MetaDataId(Guid value)
    {
        Value = value;
    }

    public static MetaDataId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}