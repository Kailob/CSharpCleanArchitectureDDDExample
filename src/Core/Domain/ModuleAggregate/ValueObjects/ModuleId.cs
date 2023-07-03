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
    /// Create ModuleId.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>ModuleId instance.</returns>
    public static ModuleId Create(Guid value) => new(value);

    /// <summary>
    /// Create Unique ModuleId.
    /// </summary>
    /// <returns>ModuleId instance.</returns>
    public static ModuleId CreateUnique() => new(Guid.NewGuid());

    /// <summary>
    /// Returns ModuleId equality components.
    /// </summary>
    /// <returns>IEnumerable object.</returns>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
