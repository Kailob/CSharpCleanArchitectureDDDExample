using Domain.Common.Models;
using Domain.DeviceAggregate.ValueObjects;
using Domain.ModuleAggregate.ValueObjects;

namespace Domain.DeviceAggregate.Entities;

/// <summary>
/// Device Module Entity.
/// </summary>
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

#pragma warning disable CS8618
    /// <summary>
    /// Default Constructor.
    /// </summary>
    private DeviceModule()
    {

    }
#pragma warning restore CS8618

    /// <summary>
    /// Gets ModuleId.
    /// </summary>
    /// <value>ModuleId.</value>
    public ModuleId ModuleId { get; private set; }

    /// <summary>
    /// Gets Variables.
    /// </summary>
    /// <value>string.</value>
    public string Variables { get; private set; }

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
    /// Initializes a new instance of the <see cref="DeviceModule"/> entity.
    /// </summary>
    /// <param name="moduleId">ModuleId.</param>
    /// <param name="variables">string.</param>
    /// <returns>DeviceModule.</returns>
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
