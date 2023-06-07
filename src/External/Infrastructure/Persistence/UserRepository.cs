using CADDD.Application.Common.Interfaces.Persistence;
using CADDD.Domain.Entities;

namespace CADDD.Infrastructure.Persistence;

public class UserRepository: IUserRepository
{
    private readonly static List<User> _users = new List<User>();

    public User? GetUserByEmail(string email) { 
        return _users.SingleOrDefault(x => x.Email == email);
    }

    public void Add(User user)
    {
        _users.Add(user);
    }
}
