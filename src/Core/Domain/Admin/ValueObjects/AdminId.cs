using CADDD.Domain.Common.Models;

namespace CADDD.Domain.Admin.ValueObjects;

public sealed class AdminId : ValueObject
{
    private AdminId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static AdminId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}