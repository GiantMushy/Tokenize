
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;

namespace Services.Implementations;
public class JwtTokenService : IJwtTokenService
{
    // i. GenerateJWT: string
    //      1. Signs the token using a signing key (stored in appsettings.json)
    //      2. Attaches the claims: Full name and email address
    //      3. Validates the issuer
    //      4. Validates the audience
    
    private string _validIssuer;
    private string _validAudience;
    private object _signingKey;

    public JwtTokenService(IConfiguration configuration)
    {
        var tokenAuthenticationConfigurationSection = configuration.GetSection("TokenAuthentication");

        _validIssuer = tokenAuthenticationConfigurationSection.GetValue<string>("Issuer") ?? throw new ArgumentException("Issuer not found in configuration.");
        _validAudience = tokenAuthenticationConfigurationSection.GetValue<string>("Audience") ?? throw new ArgumentException("Audience not found in configuration.");
        _signingKey = tokenAuthenticationConfigurationSection.GetValue<string>("SigningKey") ?? throw new ArgumentException("SigningKey not found in configuration.");
    }
    public string GenerateJwt(ClaimsPrincipal claims)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes((string)_signingKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _validIssuer,
            audience: _validAudience,
            claims: claims.Claims,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}