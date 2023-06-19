using Domain.Common.Models;
using Domain.Module.ValueObjects;
using Domain.PhysicalDevice.ValueObjects;

namespace Domain.PhysicalDevice.Entities;

public sealed class DeviceModule : Entity<DeviceModuleId>
{
    private DeviceModule(
        DeviceModuleId id,
        ModuleId moduleId,
        string variables)
        : base(id)
    {
        ModuleId = moduleId;
        Variables = variables;
    }

    public ModuleId ModuleId { get; }

    public string Variables { get; }

    public DateTime CreatedDateTime { get; } = DateTime.Now;

    public DateTime UpdatedDateTime { get; } = DateTime.Now;

    public static DeviceModule Create(
        ModuleId moduleId,
        string variables)
    {
        return new(
            DeviceModuleId.CreateUnique(),
            moduleId,
            variables);
    }
}
