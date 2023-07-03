using Domain.Common.Models;

namespace Domain.DeviceAggregate.ValueObjects;

/// <summary>
/// CameraId Value Object.
/// </summary>
public sealed class CameraId : ValueObject
{
    private CameraId(Guid value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets value.
    /// </summary>
    /// <value>Guid.</value>
    public Guid Value { get; }

    /// <summary>
    /// Create CameraId.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>CameraId instance.</returns>
    public static CameraId Create(Guid value) => new(value);

    /// <summary>
    /// Create Unique CameraId.
    /// </summary>
    /// <returns>CameraId instance.</returns>
    public static CameraId CreateUnique() => new(Guid.NewGuid());

    /// <summary>
    /// Returns CameraId equality components.
    /// </summary>
    /// <returns>IEnumerable object.</returns>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
