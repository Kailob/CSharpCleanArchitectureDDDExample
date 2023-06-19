using Application.Common.Interfaces.Persistence;

using Domain.Entities;

namespace Infrastructure.Persistence;

public class UserRepository
    : IUserRepository
{
    private static readonly List<User> _users = new List<User>();

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(x => x.Email == email);
    }

    public void Add(User user)
    {
        _users.Add(user);
    }
}