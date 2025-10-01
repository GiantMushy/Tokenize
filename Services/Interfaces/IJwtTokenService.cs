
namespace Services.Interfaces;
public interface IJwtTokenService
{
    // i. GenerateJWT: string
    string GenerateJWT(string fullName, string email);
}