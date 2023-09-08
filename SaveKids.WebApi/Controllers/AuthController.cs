using Microsoft.AspNetCore.Mvc;
using SaveKids.Service.Interfaces;

namespace SaveKids.WebApi.Controllers;

public class AuthController : BaseController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpGet("login")]
    public async Task<IActionResult> GenerateToken(string telNumber, string passwor)
        => Ok(await _authService.GenerateTokenAsync(telNumber, passwor));
}
