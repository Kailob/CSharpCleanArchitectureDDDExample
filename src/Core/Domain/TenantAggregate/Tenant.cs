using Domain.Common.Enums;
using Domain.Common.Models;
using Domain.StoreAggregate.ValueObjects;
using Domain.TenantAggregate.ValueObjects;

namespace Domain.TenantAggregate;

/// <summary>
/// Tenant Aggregate.
/// </summary>
public sealed class Tenant : AggregateRoot<TenantId>
{
    private readonly List<StoreId> _storeIds = new();

    private Tenant(
        TenantId id,
        string name,
        string description,
        EntityStatus status,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    : base(id)
    {
        Name = name;
        Description = description;
        Status = status;
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
    /// Gets StoreIds.
    /// </summary>
    /// <returns>IReadOnlyList of StoreId.</returns>
    public IReadOnlyList<StoreId> StoreIds => _storeIds.AsReadOnly();

    /// <summary>
    /// Initializes a new instance of the <see cref="Tenant"/> aggregate.
    /// </summary>
    /// <param name="name">Device Name.</param>
    /// <param name="description">Description.</param>
    /// <param name="status">Entity Status.</param>
    /// <returns>Tenant instance.</returns>
    public static Tenant Create(
        string name,
        string description,
        EntityStatus status)
    {
        return new(
            TenantId.CreateUnique(),
            name,
            description,
            status,
            DateTime.Now,
            DateTime.Now);
    }
}
