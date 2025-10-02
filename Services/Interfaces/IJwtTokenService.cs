
using System.Security.Claims;

namespace Services.Interfaces;
public interface IJwtTokenService
{
    // i. GenerateJWT: string
    string GenerateJwt(ClaimsPrincipal claims);
}