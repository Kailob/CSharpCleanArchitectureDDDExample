using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.Authentication;

public class JwtSettingsSetup : IConfigureOptions<JwtSettings>
{
    private readonly IConfiguration _configuration;

    public JwtSettingsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtSettings options)
    {
        _configuration
            .GetSection(nameof(JwtSettings))
            .Bind(options);
    }
}