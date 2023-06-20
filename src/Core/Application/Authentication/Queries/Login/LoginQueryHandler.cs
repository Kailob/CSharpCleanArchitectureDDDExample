using Application.Authentication.Common;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;

using Domain.Common.Errors;
using Domain.Entities;

using ErrorOr;

using MediatR;

namespace Application.Authentication.Queries.Login;

/// <summary>
/// Login Query Handler.
/// </summary>
public class LoginQueryHandler :
    IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwTokenGenerator _jwTokenGenerator;
    private readonly IUserRepository _userRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="LoginQueryHandler"/> class.
    /// Login.
    /// </summary>
    /// <param name="jwTokenGenerator">jwTokenGenerator string.</param>
    /// <param name="userRepository">IUserRepository.</param>
    public LoginQueryHandler(IJwTokenGenerator jwTokenGenerator, IUserRepository userRepository)
    {
        _jwTokenGenerator = jwTokenGenerator;
        _userRepository = userRepository;
    }

    /// <summary>
    /// Handles Login Query Task.
    /// </summary>
    /// <param name="query">LoginQuery.</param>
    /// <param name="cancellationToken">CancellationToken.</param>
    /// <returns>Error or Authentication Result.</returns>
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
