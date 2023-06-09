
using CADDD.Domain.Client.ValueObjects;
using CADDD.Domain.Common.Models;
using CADDD.Domain.User.ValueObjects;

namespace CADDD.Domain.User;

public sealed class User : AggregateRoot<UserId>
{
    private readonly List<ClientId> _clientIds = new();

    public DateTime CreatedDateTime { get; } = DateTime.Now;
    public DateTime UpdatedDateTime { get; } = DateTime.Now;
    public IReadOnlyList<ClientId> ClientIds => _clientIds.AsReadOnly();
  

    private User(
        UserId id
        ) : base(id)
    {
        
    }
    public static User Create(
    )
    {
        return new(
            UserId.CreateUnique()
        );
        
    }
}