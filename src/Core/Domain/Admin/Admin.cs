using CADDD.Domain.Admin.ValueObjects;
using CADDD.Domain.Common.Models;
using CADDD.Domain.Tenant.ValueObjects;

namespace CADDD.Domain.Admin;

public sealed class Admin : AggregateRoot<AdminId>
{
    public string Name { get; }
    public string Description { get; }
    public DateTime CreatedDateTime { get; } = DateTime.Now;
    public DateTime UpdatedDateTime { get; } = DateTime.Now;

    private Admin(
        AdminId id,
        string name,
        string description
        ) : base(id)
    {
        Name = name;
        Description = description;
    }
    public static Admin Create(
        string name,
        string description
    )
    {
        return new(
            AdminId.CreateUnique(),
            name,
            description
        );
        
    }
}