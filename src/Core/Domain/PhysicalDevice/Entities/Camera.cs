using Domain.Common.Models;
using Domain.PhysicalDevice.ValueObjects;

namespace Domain.PhysicalDevice.Entities;

public sealed class Camera : Entity<CameraId>
{
    private Camera(
        CameraId id,
        string name,
        string description)
        : base(id)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; }

    public string Description { get; }

    public DateTime CreatedDateTime { get; } = DateTime.Now;

    public DateTime UpdatedDateTime { get; } = DateTime.Now;

    public static Camera Create(
        string name,
        string description)
    {
        return new(
            CameraId.CreateUnique(),
            name,
            description);
    }
}
