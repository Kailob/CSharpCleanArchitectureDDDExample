using CADDD.Application.Common.Interfaces.Authentication;

namespace CADDD.Application.Services.Authentication;

public class AuthenticationService: IAuthenticationService
{
    private readonly IJwTokenGenerator _jwTokenGenerator;

    public AuthenticationService(IJwTokenGenerator jwTokenGenerator)
    {
        _jwTokenGenerator = jwTokenGenerator;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password){
        // Check if user already exists
        // Create User (generate unique ID) 
        var userId = Guid.NewGuid();
        // Create JwT Token
        var token = _jwTokenGenerator.GenerateToken(userId, firstName, lastName);
        return new AuthenticationResult(
            Guid.NewGuid(),
            firstName,
            lastName,
            email,
            token
        );
    }
    public AuthenticationResult Login(string email, string password) {
        return new AuthenticationResult(
            Guid.NewGuid(),
            "firstName",
            "lastName",
            email,
            "token"
        );
    }
}