using CADDD.Domain.Entities;

namespace CADDD.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);