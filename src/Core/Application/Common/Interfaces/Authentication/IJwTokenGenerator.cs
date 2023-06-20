using Domain.Entities;

namespace Application.Common.Interfaces.Authentication;

/// <summary>
/// Interface for Jw Token Generator.
/// </summary>
public interface IJwTokenGenerator
{
    /// <summary>
    /// Generate Token.
    /// </summary>
    /// <param name="user">User.</param>
    /// <returns>string.</returns>
    string GenerateToken(User user);
}
