using Domain.Entities;

namespace Application.Authentication.Common;

/// <summary>
/// Authentication Result.
/// </summary>
/// <param name="User">User.</param>
/// <param name="Token">Token String.</param>
/// <returns>AuthenticationResult.</returns>
public record AuthenticationResult(
    User User,
    string Token);
