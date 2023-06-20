using Application.Common.Interfaces.Persistence;

using Domain.Entities;

namespace Infrastructure.Persistence;

/// <summary>
/// User Repository. IUserRepository implementation.
/// </summary>
public class UserRepository
    : IUserRepository
{
    private static readonly List<User> _users = new List<User>();

    /// <summary>
    /// Get User by Email.
    /// </summary>
    /// <param name="email">Email.</param>
    /// <returns>User.</returns>
    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(x => x.Email == email);
    }

    /// <summary>
    /// Adds new user to database.
    /// </summary>
    /// <param name="user">User.</param>
    public void Add(User user)
    {
        _users.Add(user);
    }
}
