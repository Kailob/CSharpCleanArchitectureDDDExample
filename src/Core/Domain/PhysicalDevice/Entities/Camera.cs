


using CADDD.Domain.Common.Models;
using CADDD.Domain.PhysicalDevice.ValueObjects;

namespace CADDD.Domain.PhysicalDevice.Entities;

public sealed class Camera : Entity<CameraId>
{
    public string Name { get; }
    public string Description { get; }
    public DateTime CreatedDateTime { get; } = DateTime.Now;
    public DateTime UpdatedDateTime { get; } = DateTime.Now;

    private Camera(
        CameraId id, 
        string name,
        string description
    ) : base(id)
    {
        Name = name;
        Description = description;
    }

    public static Camera Create(
        string name,
        string description
    )
    {
        return new(
            CameraId.CreateUnique(),
            name,
            description
        );
        
    }
}