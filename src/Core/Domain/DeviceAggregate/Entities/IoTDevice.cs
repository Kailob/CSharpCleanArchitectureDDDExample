using Domain.Common.Enums;
using Domain.Common.Models;
using Domain.DeviceAggregate.ValueObjects;

namespace Domain.DeviceAggregate.Entities;

/// <summary>
/// IoT Device Entity.
/// </summary>
public sealed class IoTDevice : Entity<IoTDeviceId>
{
    private IoTDevice(
        IoTDeviceId id,
        string name,
        EntityStatus status)
        : base(id)
    {
        Name = name;
        Status = status;
    }

    /// <summary>
    /// Gets Name.
    /// </summary>
    /// <value>string.</value>
    public string Name { get; }

    /// <summary>
    /// Gets Entity Status.
    /// </summary>
    /// <value>EntityStatus.</value>
    public EntityStatus Status { get; }

    /// <summary>
    /// Gets created date-time. Default to DateTime.Now.
    /// </summary>
    /// <value>DateTime.</value>
    public DateTime CreatedDateTime { get; } = DateTime.Now;

    /// <summary>
    /// Initializes a new instance of the <see cref="IoTDevice"/> entity.
    /// </summary>
    /// <param name="name">string.</param>
    /// <param name="status">Entity Status.</param>
    /// <returns>IoTDevice.</returns>
    public static IoTDevice Create(
        string name,
        EntityStatus status)
    {
        return new(
            IoTDeviceId.CreateUnique(),
            name,
            status);
    }
}
