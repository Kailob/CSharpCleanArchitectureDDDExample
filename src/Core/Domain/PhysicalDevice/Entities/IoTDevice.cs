using Domain.Common.Enums;
using Domain.Common.Models;
using Domain.PhysicalDevice.ValueObjects;

namespace Domain.PhysicalDevice.Entities;

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

    public string Name { get; }

    public EntityStatus Status { get; }

    public DateTime CreatedDateTime { get; } = DateTime.Now;

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
