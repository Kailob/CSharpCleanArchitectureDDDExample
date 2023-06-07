using CADDD.Application.Common.Errors;
using CADDD.Application.Common.Interfaces.Authentication;
using CADDD.Application.Common.Interfaces.Persistence;
using CADDD.Domain.Entities;

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

    public AuthenticationResult Register(string firstName, string lastName, string email, string password){
        // Check if user already exists
        if (_userRepository.GetUserByEmail(email) is not null) {
            throw new DuplicateEmailException();
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
    public AuthenticationResult Login(string email, string password) {
        // Check if user already exists
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with given email does not exist.");
        }

        // Check if password matches
        if (user.Password != password)
        {
            throw new Exception("Invalid Password");
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