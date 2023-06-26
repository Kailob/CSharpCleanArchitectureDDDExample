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
    }

    /// <summary>
    /// Gets the Manifest.
    /// </summary>
    /// <value>string.</value>
    public string Manifest { get; }

    /// <summary>
    /// Gets created date-time. Default to DateTime.Now.
    /// </summary>
    /// <value>DateTime.</value>
    public DateTime CreatedDateTime { get; } = DateTime.Now;

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
