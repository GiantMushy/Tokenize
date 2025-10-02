
using Microsoft.AspNetCore.Mvc;
using Models.InputModels;
using Services.Interfaces;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    // i. Register
    // ii. Login
    private readonly IAccountService _accountService;
    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterInputModel registerInputModel)
    {
        _accountService.Register(registerInputModel);
        return Created();
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginInputModel loginInputModel)
    {
        var token = _accountService.Login(loginInputModel);
        return string.IsNullOrEmpty(token) ? Unauthorized() : Ok(token);
    }
}