using CADDD.Domain.Common.Enums;
using CADDD.Domain.Common.Models;
using CADDD.Domain.PhysicalDevice.ValueObjects;

namespace CADDD.Domain.PhysicalDevice.Entities;

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