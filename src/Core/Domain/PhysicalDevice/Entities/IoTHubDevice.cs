


using CADDD.Domain.Common.Enums;
using CADDD.Domain.Common.Models;
using CADDD.Domain.PhysicalDevice.ValueObjects;

namespace CADDD.Domain.PhysicalDevice.Entities;

public sealed class IoTHubDevice : Entity<IoTHubDeviceId>
{
    public string Name { get; }
    public EntityStatus Status { get; }
    public DateTime CreatedDateTime { get; } = DateTime.Now;

    private IoTHubDevice(
        IoTHubDeviceId id, 
        string name,
        EntityStatus status
    ) : base(id)
    {
        Name = name;
        Status = status;
    }

    public static IoTHubDevice Create(
        string name,
        EntityStatus status
    )
    {
        return new(
            IoTHubDeviceId.CreateUnique(),
            name,
            status
        );
        
    }
}