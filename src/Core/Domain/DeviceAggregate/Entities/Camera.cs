using Domain.Common.Models;
using Domain.DeviceAggregate.ValueObjects;

namespace Domain.DeviceAggregate.Entities;

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

#pragma warning disable CS8618
    /// <summary>
    /// Default Constructor.
    /// </summary>
    private Camera()
    {

    }
#pragma warning restore CS8618

    /// <summary>
    /// Gets Name.
    /// </summary>
    /// <value>string.</value>
    public string Name { get; private set; }

    /// <summary>
    /// Gets Description.
    /// </summary>
    /// <value>string.</value>
    public string Description { get; private set; }

    /// <summary>
    /// Gets created date-time. Default to DateTime.Now.
    /// </summary>
    /// <value>DateTime.</value>
    public DateTime CreatedDateTime { get; private set; } = DateTime.Now;

    /// <summary>
    /// Gets updated date-time. Default to DateTime.Now.
    /// </summary>
    /// <value>DateTime.</value>
    public DateTime UpdatedDateTime { get; private set; } = DateTime.Now;

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
