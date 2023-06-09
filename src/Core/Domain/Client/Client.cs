
using CADDD.Domain.Common.Models;
using CADDD.Domain.Client.ValueObjects;
using CADDD.Domain.Tenant.ValueObjects;

namespace CADDD.Domain.Client;

public sealed class Client : AggregateRoot<ClientId>
{
    private readonly List<TenantId> _tenantIds = new();
    public string Name { get; }
    public string Description { get; }
    public DateTime CreatedDateTime { get; } = DateTime.Now;
    public DateTime UpdatedDateTime { get; } = DateTime.Now;
    public IReadOnlyList<TenantId> TenantIds => _tenantIds.AsReadOnly();

    private Client(
        ClientId id,
        string name,
        string description
        ) : base(id)
    {
        Name = name;
        Description = description;
    }
    public static Client Create(
        string name,
        string description
    )
    {
        return new(
            ClientId.CreateUnique(),
            name,
            description
        );
        
    }
}