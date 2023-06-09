using CADDD.Domain.Common.Models;

namespace CADDD.Domain.Admin.ValueObjects;

public sealed class AdminId : ValueObject
{
    public Guid Value { get; }

    private AdminId(Guid value)
    {
        Value = value;
    }

    public static AdminId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}