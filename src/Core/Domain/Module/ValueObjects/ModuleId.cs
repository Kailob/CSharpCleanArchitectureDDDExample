using Domain.Common.Models;

namespace Domain.Module.ValueObjects;

public sealed class ModuleId : ValueObject
{
    private ModuleId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static ModuleId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
