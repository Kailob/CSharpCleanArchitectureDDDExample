using Domain.Common.Enums;
using Domain.Common.Models;
using Domain.DeviceAggregate.ValueObjects;
using Domain.StoreAggregate.ValueObjects;
using Domain.TenantAggregate.ValueObjects;

namespace Domain.StoreAggregate;

/// <summary>
/// Store Aggregate.
/// </summary>
public sealed class Store : AggregateRoot<StoreId>
{
    private readonly List<DeviceId> _deviceIds = new();

    private Store(
        StoreId id,
        string name,
        string description,
        EntityStatus status,
        TenantId tenantId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    : base(id)
    {
        Name = name;
        Description = description;
        Status = status;
        TenantId = tenantId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
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
    /// Gets entity status.
    /// </summary>
    /// <value>EntityStatus.</value>
    public EntityStatus Status { get; }

    /// <summary>
    /// Gets TenantId value object.
    /// </summary>
    /// <value>TenantId.</value>
    public TenantId TenantId { get; }

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
    /// Gets DeviceIds.
    /// </summary>
    /// <returns>IReadOnlyList of DeviceId.</returns>
    public IReadOnlyList<DeviceId> DeviceIds => _deviceIds.AsReadOnly();

    /// <summary>
    /// Initializes a new instance of the <see cref="Store"/> aggregate.
    /// </summary>
    /// <param name="name">Device Name.</param>
    /// <param name="description">Description.</param>
    /// <param name="status">Entity Status.</param>
    /// <param name="tenantId">Tenant Id.</param>
    /// <returns>Store instance.</returns>
    public static Store Create(
        string name,
        string description,
        EntityStatus status,
        TenantId tenantId) => new(
            StoreId.CreateUnique(),
            name,
            description,
            status,
            tenantId,
            DateTime.Now,
            DateTime.Now
            );
}
