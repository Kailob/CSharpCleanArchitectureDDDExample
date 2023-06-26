using Domain.Common.Models;

namespace Domain.ModuleAggregate.ValueObjects;

/// <summary>
/// ModuleId Value Object.
/// </summary>
public sealed class ModuleId : ValueObject
{
    private ModuleId(Guid value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets value.
    /// </summary>
    /// <value>Guid.</value>
    public Guid Value { get; }

    /// <summary>
    /// Create Unique ModuleId.
    /// </summary>
    /// <returns>ModuleId instance.</returns>
    public static ModuleId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    /// <summary>
    /// Returns ModuleId equality components.
    /// </summary>
    /// <returns>IEnumerable object.</returns>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
