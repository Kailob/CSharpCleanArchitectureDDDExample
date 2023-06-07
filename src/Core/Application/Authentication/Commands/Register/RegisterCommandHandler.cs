using CADDD.Application.Authentication.Common;
using CADDD.Application.Common.Interfaces.Authentication;
using CADDD.Application.Common.Interfaces.Persistence;
using CADDD.Domain.Common.Errors;
using CADDD.Domain.Entities;
using ErrorOr;
using MediatR;

namespace CADDD.Application.Authentication.Commands.Register;

public class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwTokenGenerator _jwTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwTokenGenerator jwTokenGenerator, IUserRepository userRepository)
    {
        _jwTokenGenerator = jwTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        // Check if user already exists
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        // Create User (generate unique ID) 
        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
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
}
