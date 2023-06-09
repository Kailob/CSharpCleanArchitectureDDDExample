
using CADDD.Domain.Common.Models;

namespace CADDD.Domain.Module.ValueObjects;

public sealed class ModuleId : ValueObject
{
    public Guid Value { get; }

    private ModuleId(Guid value)
    {
        Value = value;
    }

    public static ModuleId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
       yield return Value;
    }
}