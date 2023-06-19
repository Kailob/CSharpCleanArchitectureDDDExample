using Domain.Client.ValueObjects;
using Domain.Common.Models;
using Domain.User.ValueObjects;

namespace Domain.User;

/// <summary>
/// User Aggregate.
/// </summary>
public sealed class User : AggregateRoot<UserId>
{
    private readonly List<ClientId> _clientIds = new();

    private User(UserId id)
    : base(id)
    {
    }

    /// <summary>
    /// Gets User CreateDateTime. Default to DateTime.Now.
    /// </summary>
    /// <value>DateTime.</value>
    public DateTime CreatedDateTime { get; } = DateTime.Now;

    /// <summary>
    /// Gets User UpdateDateTime. Default to DateTime.Now.
    /// </summary>
    /// <value>DateTime.</value>
    public DateTime UpdatedDateTime { get; } = DateTime.Now;

    /// <summary>
    /// Gets List of Client Ids.
    /// </summary>
    /// <returns>IReadOnlyList.</returns>
    public IReadOnlyList<ClientId> ClientIds => _clientIds.AsReadOnly();

    /// <summary>
    /// Create a new User Aggregate.
    /// </summary>
    /// <returns>User Aggregate.</returns>
    public static User Create()
    {
        return new(UserId.CreateUnique());
    }
}
