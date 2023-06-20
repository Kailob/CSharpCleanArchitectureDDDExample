using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.Authentication;

/// <summary>
/// Jwt Settings Setup.
/// </summary>
public class JwtSettingsSetup : IConfigureOptions<JwtSettings>
{
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Initializes a new instance of the <see cref="JwtSettingsSetup"/> class.
    /// </summary>
    /// <param name="configuration">IConfiguration.</param>
    public JwtSettingsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Binds JwtSettings to app configurations.
    /// </summary>
    /// <param name="options">JwtSettings.</param>
    public void Configure(JwtSettings options)
    {
        _configuration
            .GetSection(nameof(JwtSettings))
            .Bind(options);
    }
}
