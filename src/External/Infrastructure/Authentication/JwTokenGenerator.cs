using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Services;

using Domain.Entities;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Authentication;

/// <summary>
/// JwToken Generator.
/// </summary>
public class JwTokenGenerator
    : IJwTokenGenerator
{
    private readonly JwtSettings _jwtSettings;
    private readonly IDateTimeProvider _dateTime;

    /// <summary>
    /// Initializes a new instance of the <see cref="JwTokenGenerator"/> class.
    /// </summary>
    /// <param name="dateTime">IDateTimeProvider.</param>
    /// <param name="jwtOptions">IOptions{JwtSettings}.</param>
    public JwTokenGenerator(
        IDateTimeProvider dateTime,
        IOptions<JwtSettings> jwtOptions)
    {
        _dateTime = dateTime;
        _jwtSettings = jwtOptions.Value;
    }

    /// <summary>
    /// Generate Token.
    /// </summary>
    /// <param name="user">User.</param>
    /// <returns>Token string.</returns>
    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
