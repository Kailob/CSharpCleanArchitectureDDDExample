using Application.Authentication.Common;

using ErrorOr;

using MediatR;

namespace Application.Authentication.Commands.Register;

/// <summary>
/// Register Command.
/// </summary>
/// <param name="FirstName">First Name.</param>
/// <param name="LastName">Last Name.</param>
/// <param name="Email">Email.</param>
/// <param name="Password">Password.</param>
/// <returns>RegisterCommand.</returns>
public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password)
    : IRequest<ErrorOr<AuthenticationResult>>;
