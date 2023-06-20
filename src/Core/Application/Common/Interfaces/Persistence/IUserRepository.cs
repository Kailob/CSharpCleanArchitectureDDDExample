using Domain.Entities;

namespace Application.Common.Interfaces.Persistence;

/// <summary>
/// interface for User Repository.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Get User by Email.
    /// </summary>
    /// <param name="email">Email.</param>
    /// <returns>User.</returns>
    User? GetUserByEmail(string email);

    /// <summary>
    /// Adds new user to database.
    /// </summary>
    /// <param name="user">User.</param>
    void Add(User user);
}
