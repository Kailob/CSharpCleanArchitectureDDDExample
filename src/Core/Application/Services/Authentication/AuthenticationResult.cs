using CADDD.Domain.Entities;

namespace CADDD.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token
);