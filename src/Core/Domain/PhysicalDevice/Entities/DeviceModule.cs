


using CADDD.Domain.Common.Models;
using CADDD.Domain.Module.ValueObjects;
using CADDD.Domain.PhysicalDevice.ValueObjects;

namespace CADDD.Domain.PhysicalDevice.Entities;

public sealed class DeviceModule : Entity<DeviceModuleId>
{
    public ModuleId ModuleId { get; }
    public string Variables { get; }
    public DateTime CreatedDateTime { get; } = DateTime.Now;
    public DateTime UpdatedDateTime { get; } = DateTime.Now;

    private DeviceModule(
        DeviceModuleId id, 
        ModuleId moduleId,
        string variables
    ) : base(id)
    {
        ModuleId = moduleId;
        Variables = variables;
    }

    public static DeviceModule Create(
        ModuleId moduleId,
        string variables
    )
    {
        return new(
            DeviceModuleId.CreateUnique(),
            moduleId,
            variables
        );
        
    }
}