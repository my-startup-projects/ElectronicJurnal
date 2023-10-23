using ElectronicJurnal.Server.Services;
using ElectronicJurnal.Shared.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicJurnal.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthenticationService _authService;

    public AuthController(AuthenticationService authService)
    {
        _authService = authService;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var result = await _authService.Login(request.Username, request.Password);
        return Ok(result);
    } 
    
    [HttpPost("[action]")]
    public async Task<IActionResult> Register([FromBody] ApplicationUser request)
    {
        var result = await _authService.Register(request);
        return Ok(result);
    }
}

public class LoginRequest
{
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
}