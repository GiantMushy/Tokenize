
using Services.Interfaces;

namespace Services.Implementations;
public class JwtTokenService : IJwtTokenService
{
    // i. GenerateJWT: string
        // 1. Signs the token using a signing key (stored in appsettings.json)
        // 2. Attaches the claims: Full name and email address
        // 3. Validates the issuer
        // 4. Validates the audience
    public string GenerateJWT(string fullName, string email)
    {
        // Logic to generate JWT token
        throw new NotImplementedException();
    }
    
}