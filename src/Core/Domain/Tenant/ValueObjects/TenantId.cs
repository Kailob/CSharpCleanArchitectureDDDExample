using Domain.Common.Models;

namespace Domain.Tenant.ValueObjects;

/// <summary>
/// Tenant Id value object.
/// </summary>
public sealed class TenantId : ValueObject
{
    private TenantId(Guid value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets value.
    /// </summary>
    /// <value>Guid.</value>
    public Guid Value { get; }

    /// <summary>
    /// Create Unique TenantId.
    /// </summary>
    /// <returns>TenantId instance.</returns>
    public static TenantId CreateUnique() => new(Guid.NewGuid());

    /// <summary>
    /// Returns Tenant Id equality components.
    /// </summary>
    /// <returns>IEnumerable object.</returns>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
