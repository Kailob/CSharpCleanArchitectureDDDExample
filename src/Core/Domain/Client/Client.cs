using Domain.Client.ValueObjects;
using Domain.Common.Models;
using Domain.Tenant.ValueObjects;

namespace Domain.Client;

/// <summary>
/// Client aggregate.
/// </summary>
public sealed class Client : AggregateRoot<ClientId>
{
    private readonly List<TenantId> _tenantIds = new();

    private Client(
        ClientId id,
        string name,
        string description)
        : base(id)
    {
        Name = name;
        Description = description;
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
    /// Gets tenantIds list.
    /// </summary>
    /// <returns>IReadOnlyList of TenantIds.</returns>
    public IReadOnlyList<TenantId> TenantIds => _tenantIds.AsReadOnly();

    /// <summary>
    /// Initializes a new instance of the <see cref="Client"/> aggregate.
    /// </summary>
    /// <param name="name">Name.</param>
    /// <param name="description">description.</param>
    /// <returns>Admin instance.</returns>
    public static Client Create(
        string name,
        string description)
    {
        return new(
            ClientId.CreateUnique(),
            name,
            description);
    }
}
