
using CADDD.Domain.Client.ValueObjects;
using CADDD.Domain.Common.Models;
using CADDD.Domain.PhysicalDevice.ValueObjects;
using CADDD.Domain.Tenant.ValueObjects;

namespace CADDD.Domain.Tenant;

public sealed class Tenant : AggregateRoot<TenantId>
{
    private readonly List<PhysicalDeviceId> _physicalDeviceIds = new();
    public ClientId ClientId { get; }
    public DateTime CreatedDateTime { get; } = DateTime.Now;
    public DateTime UpdatedDateTime { get; } = DateTime.Now;
    public IReadOnlyList<PhysicalDeviceId> PhysicalDeviceIds => _physicalDeviceIds.AsReadOnly();
  

    private Tenant(
        TenantId id,
        ClientId clientId
        ) : base(id)
    {
        ClientId = clientId;
    }
    public static Tenant Create(
        ClientId clientId
    )
    {
        return new(
            TenantId.CreateUnique(),
            clientId
        );
        
    }
}