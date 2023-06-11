using CADDD.Application.Authentication.Common;
using CADDD.Application.Common.Interfaces.Authentication;
using CADDD.Application.Common.Interfaces.Persistence;
using CADDD.Domain.Common.Errors;
using CADDD.Domain.Entities;
using ErrorOr;
using MediatR;

namespace CADDD.Application.Authentication.Queries.Login;

public class LoginQueryHandler :
    IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwTokenGenerator _jwTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwTokenGenerator jwTokenGenerator, IUserRepository userRepository)
    {
        _jwTokenGenerator = jwTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask; // Clears annoying warning on Handle

        // Check if user already exists
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // Check if password matches
        if (user.Password != query.Password)
        {
            return new[] { Errors.Authentication.InvalidCredentials };
        }

        // Create JwT Token
        var token = _jwTokenGenerator.GenerateToken(user);

        // Return
        return new AuthenticationResult(
            user,
            token);
    }
}