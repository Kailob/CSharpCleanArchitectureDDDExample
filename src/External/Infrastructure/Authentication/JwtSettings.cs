namespace Infrastructure.Authentication;

/// <summary>
/// Jwt Settings.
/// </summary>
public class JwtSettings
{
    /// <summary>
    /// Gets or sets secret.
    /// </summary>
    /// <value>string.</value>
    public string Secret { get; set; } = null!;

    /// <summary>
    /// Gets or sets expiryMinutes.
    /// </summary>
    /// <value>int.</value>
    public int ExpiryMinutes { get; set; }

    /// <summary>
    /// Gets or sets issuer.
    /// </summary>
    /// <value>string.</value>
    public string Issuer { get; set; } = null!;

    /// <summary>
    /// Gets or sets audience.
    /// </summary>
    /// <value>string.</value>
    public string Audience { get; set; } = null!;
}
