using Domain.Common.Models;
using Domain.PhysicalDevice.ValueObjects;

namespace Domain.PhysicalDevice.Entities;

/// <summary>
/// Camera Entity.
/// </summary>
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

    /// <summary>
    /// Gets Name.
    /// </summary>
    /// <value>string.</value>
    public string Name { get; }

    /// <summary>
    /// Gets Description.
    /// </summary>
    /// <value>string.</value>
    public string Description { get; }

    /// <summary>
    /// Gets created date-time. Default to DateTime.Now.
    /// </summary>
    /// <value>DateTime.</value>
    public DateTime CreatedDateTime { get; } = DateTime.Now;

    /// <summary>
    /// Gets updated date-time. Default to DateTime.Now.
    /// </summary>
    /// <value>DateTime.</value>
    public DateTime UpdatedDateTime { get; } = DateTime.Now;

    /// <summary>
    /// Initializes a new instance of the <see cref="Camera"/> entity.
    /// </summary>
    /// <param name="name">Name.</param>
    /// <param name="description">Description.</param>
    /// <returns>Camera.</returns>
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
