
using Microsoft.EntityFrameworkCore;
using Models.InputModels;
using Repositories.Interfaces;
using Services.Interfaces;
using Services.Utilities;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Services.Implementations;

public class AccountService : IAccountService
{
    private readonly IAccountRepo _accountRepo;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly string _salt;
    public AccountService(IAccountRepo accountRepo, IConfiguration configuration, IJwtTokenService jwtTokenService)
    {
        _accountRepo = accountRepo;
        _salt = configuration.GetValue<string>("CookieAuthentication:Salt") ?? throw new ArgumentException("Salt not found in configuration.");
        _jwtTokenService = jwtTokenService;
    }
    // ii. Register: void
    // iii. Login: string
    public void Register(RegisterInputModel user)
    {
        var hashedPassword = Hasher.HashPassword(user.Password, _salt);
        _accountRepo.Register(user, hashedPassword);
    }

    public string Login(LoginInputModel inputModel)
    {
        var user = _accountRepo.GetUser(inputModel.EmailAddress, Hasher.HashPassword(inputModel.Password, _salt));
        if (user == null)
        {
            throw new UnauthorizedAccessException("Invalid email or password.");
        }

        var claims = new List<Claim>
        {
            new (ClaimTypes.Name, user.EmailAddress),
            new ("FullName", user.FullName),
        };

        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(claimsIdentity);

        return _jwtTokenService.GenerateJwt(principal);
    }
}