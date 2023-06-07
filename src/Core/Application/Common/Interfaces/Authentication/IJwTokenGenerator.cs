using CADDD.Domain.Entities;

namespace CADDD.Application.Common.Interfaces.Authentication;

public interface IJwTokenGenerator
{
    string GenerateToken(User user);
}