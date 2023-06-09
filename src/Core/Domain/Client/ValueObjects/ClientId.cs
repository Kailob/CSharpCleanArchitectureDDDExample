
using CADDD.Domain.Common.Models;

namespace CADDD.Domain.Client.ValueObjects;

public sealed class ClientId : ValueObject
{
    public Guid Value { get; }

    private ClientId(Guid value)
    {
        Value = value;
    }

    public static ClientId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}