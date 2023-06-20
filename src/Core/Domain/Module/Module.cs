using Domain.Common.Models;
using Domain.Module.ValueObjects;
using Domain.PhysicalDevice.ValueObjects;

namespace Domain.Module;

/// <summary>
/// Module Aggregate.
/// </summary>
public sealed class Module : AggregateRoot<ModuleId>
{
    // private readonly List<PhysicalDeviceId> _physicalDeviceIds = new();
    private Module(
        ModuleId id,
        string name,
        string description,
        string dockerImage)
        : base(id)
    {
        Name = name;
        Description = description;
        DockerImage = dockerImage;
    }

    /// <summary>
    /// Gets name.
    /// </summary>
    /// <value>string.</value>
    public string Name { get; }

    /// <summary>
    /// Gets description.
    /// </summary>
    /// <value>string.</value>
    public string Description { get; }

    /// <summary>
    /// Gets docker image.
    /// </summary>
    /// <value>string.</value>
    public string DockerImage { get; }

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
    /// Initializes a new instance of the <see cref="Module"/> aggregate.
    /// </summary>
    /// <param name="name">Name.</param>
    /// <param name="description">Description.</param>
    /// <param name="dockerImage">DockerImage.</param>
    /// <returns>Module instance.</returns>
    public static Module Create(
        string name,
        string description,
        string dockerImage)
    {
        return new(
            ModuleId.CreateUnique(),
            name,
            description,
            dockerImage);
    }
}
