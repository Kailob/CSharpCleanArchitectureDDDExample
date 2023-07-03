using Domain.Common.Models;

namespace Domain.DeviceAggregate.ValueObjects;

/// <summary>
/// DeployId Value Object.
/// </summary>
public sealed class DeployId : ValueObject
{
    private DeployId(Guid value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets value.
    /// </summary>
    /// <value>Guid.</value>
    public Guid Value { get; }

    /// <summary>
    /// Create DeployId.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>DeployId instance.</returns>
    public static DeployId Create(Guid value) => new(value);

    /// <summary>
    /// Create Unique DeployId.
    /// </summary>
    /// <returns>DeployId instance.</returns>
    public static DeployId CreateUnique() => new(Guid.NewGuid());

    /// <summary>
    /// Returns DeployId equality components.
    /// </summary>
    /// <returns>IEnumerable object.</returns>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
