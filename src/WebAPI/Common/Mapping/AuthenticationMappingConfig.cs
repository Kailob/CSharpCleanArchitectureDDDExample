using CADDD.Application.Authentication.Commands.Register;
using CADDD.Application.Authentication.Common;
using CADDD.Application.Authentication.Queries.Register;
using CADDD.Contracts.Authentication;
using Mapster;

namespace CADDD.WebAPI.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.User);
    }
}
