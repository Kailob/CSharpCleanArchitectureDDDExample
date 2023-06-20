using Application.Authentication.Common;

using ErrorOr;

using MediatR;

namespace Application.Authentication.Queries.Login;

/// <summary>
/// Login Query.
/// </summary>
/// <param name="Email">Email.</param>
/// <param name="Password">Password.</param>
/// <returns>LoginQuery.</returns>
public record LoginQuery(
    string Email,
    string Password)
    : IRequest<ErrorOr<AuthenticationResult>>;
