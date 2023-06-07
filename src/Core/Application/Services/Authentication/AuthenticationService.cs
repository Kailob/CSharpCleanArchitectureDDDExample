using CADDD.Application.Common.Interfaces.Authentication;
using CADDD.Application.Common.Interfaces.Persistence;
using CADDD.Domain.Common.Errors;
using CADDD.Domain.Entities;
using ErrorOr;

namespace CADDD.Application.Services.Authentication;

public class AuthenticationService: IAuthenticationService
{
    private readonly IJwTokenGenerator _jwTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwTokenGenerator jwTokenGenerator, IUserRepository userRepository)
    {
        _jwTokenGenerator = jwTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password){
        // Check if user already exists
        if (_userRepository.GetUserByEmail(email) is not null) {
            return Errors.User.DuplicateEmail;
        }

        // Create User (generate unique ID) 
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        // Create JwT Token
        var token = _jwTokenGenerator.GenerateToken(user);

        // Return
        return new AuthenticationResult(
            user,
            token
        );
    }
    public ErrorOr<AuthenticationResult> Login(string email, string password) {
        // Check if user already exists
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // Check if password matches
        if (user.Password != password)
        {
            return new[] { Errors.Authentication.InvalidCredentials };
        }

        // Create JwT Token
        var token = _jwTokenGenerator.GenerateToken(user);

        // Return
        return new AuthenticationResult(
            user,
            token
        );
    }
}