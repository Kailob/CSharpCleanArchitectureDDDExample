using Domain.Common.Enums;
using Domain.Common.Models;
using Domain.DeviceAggregate.ValueObjects;

namespace Domain.DeviceAggregate.Entities;

/// <summary>
/// Deploy Entity.
/// </summary>
public sealed class Deploy : Entity<DeployId>
{
    private Deploy(
        DeployId id,
        string manifest)
        : base(id)
    {
        Manifest = manifest;
        ExecutionStatus = Domain.Common.Enums.ExecutionStatus.Stopped;
    }

#pragma warning disable CS8618
    /// <summary>
    /// Default Constructor.
    /// </summary>
    private Deploy()
    {
    }
#pragma warning restore CS8618

    /// <summary>
    /// Gets the Manifest.
    /// </summary>
    /// <value>string.</value>
    public string Manifest { get; private set; }

    /// <summary>
    /// Gets Software execution status.
    /// </summary>
    /// <value>ExecutionStatus.</value>
    public ExecutionStatus ExecutionStatus { get; private set; }

    /// <summary>
    /// Gets created date-time. Default to DateTime.Now.
    /// </summary>
    /// <value>DateTime.</value>
    public DateTime CreatedDateTime { get; private set; } = DateTime.Now;

    /// <summary>
    /// Initializes a new instance of the <see cref="Deploy"/> entity.
    /// </summary>
    /// <param name="manifest">Manifest.</param>
    /// <returns>Deploy.</returns>
    public static Deploy Create(
        string manifest)
    {
        return new(
            DeployId.CreateUnique(),
            manifest);
    }
}
