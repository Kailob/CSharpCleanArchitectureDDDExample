using Domain.Entities;

namespace Application.Common.Interfaces.Authentication;

public interface IJwTokenGenerator
{
    string GenerateToken(User user);
}