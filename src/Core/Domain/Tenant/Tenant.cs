using Domain.Client.ValueObjects;
using Domain.Common.Models;
using Domain.PhysicalDevice.ValueObjects;
using Domain.Tenant.ValueObjects;

namespace Domain.Tenant;

/// <summary>
/// Tenant Aggregate.
/// </summary>
public sealed class Tenant : AggregateRoot<TenantId>
{
    private readonly List<PhysicalDeviceId> _physicalDeviceIds = new();

    private Tenant(TenantId id, ClientId clientId)
    : base(id)
    {
        ClientId = clientId;
    }

    /// <summary>
    /// Gets ClientID value object.
    /// </summary>
    /// <value>ClientId.</value>
    public ClientId ClientId { get; }

    /// <summary>
    /// Gets create date-time. Default to DateTime.Now.
    /// </summary>
    /// <value>DateTime.</value>
    public DateTime CreatedDateTime { get; } = DateTime.Now;

    /// <summary>
    /// Gets updated date-time. Default to DateTime.Now.
    /// </summary>
    /// <value>DateTime.</value>
    public DateTime UpdatedDateTime { get; } = DateTime.Now;

    /// <summary>
    /// Gets PhysicalDeviceIds.
    /// </summary>
    /// <returns>IReadOnlyList of PhysicalDeviceId.</returns>
    public IReadOnlyList<PhysicalDeviceId> PhysicalDeviceIds => _physicalDeviceIds.AsReadOnly();

    /// <summary>
    /// Initializes a new instance of the <see cref="Tenant"/> aggregate.
    /// </summary>
    /// <param name="clientId">Client's Id value Object.</param>
    /// <returns>Tenant instance.</returns>
    public static Tenant Create(ClientId clientId)
    {
        return new(TenantId.CreateUnique(), clientId);
    }
}
