using CADDD.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace CADDD.Application.Authentication.Queries.Register;

public record LoginQuery(
    string Email,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;
