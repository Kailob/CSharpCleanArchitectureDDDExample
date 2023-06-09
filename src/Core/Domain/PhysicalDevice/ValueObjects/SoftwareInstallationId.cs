
using CADDD.Domain.Common.Models;

namespace CADDD.Domain.PhysicalDevice.ValueObjects;

public sealed class SoftwareInstallationId : ValueObject
{
    public Guid Value { get; }

    private SoftwareInstallationId(Guid value)
    {
        Value = value;
    }

    public static SoftwareInstallationId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}