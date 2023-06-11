using CADDD.Domain.Common.Models;

namespace CADDD.Domain.Client.ValueObjects;

public sealed class ClientId : ValueObject
{
    private ClientId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static ClientId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}