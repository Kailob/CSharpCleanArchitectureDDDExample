
using CADDD.Domain.Common.Models;
using CADDD.Domain.Module.ValueObjects;
using CADDD.Domain.PhysicalDevice.ValueObjects;

namespace CADDD.Domain.Module;

public sealed class Module : AggregateRoot<ModuleId>
{
    private readonly List<PhysicalDeviceId> _physicalDeviceIds = new();
    public string Name { get; }
    public string Description { get; }
    public string DockerImage { get; }
    public DateTime CreatedDateTime { get; } = DateTime.Now;
    public DateTime UpdatedDateTime { get; } = DateTime.Now;
    private Module(
        ModuleId id,
        string name,
        string description,
        string dockerImage) : base(id)
    {
        Name = name;
        Description = description;
        DockerImage = dockerImage;
    }
    public static Module Create(
        string name,
        string description,
        string dockerImage
    )
    {
        return new(
            ModuleId.CreateUnique(),
            name,
            description,
            dockerImage
        );
        
    }
}