using Microsoft.AspNetCore.Mvc;
using VisualFXVault.Domain.DTOs;
using VisualFXVault.Domain.Interfaces.Services;

namespace VisualFXVault.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUsersService _usersService;

    public AuthController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequestDto registerRequest)
    {
        if (registerRequest == null)
        {
            return BadRequest("Invalid registration request.");
        }

        var authResponse = await _usersService.RegisterAsync(registerRequest);
        
        return authResponse?.IsSuccessful == true 
            ? Ok(authResponse) 
            : BadRequest(authResponse);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestDto loginRequest)
    {
        if (loginRequest == null)
        {
            return BadRequest("Invalid login request.");
        }

        var authResponse = await _usersService.LoginAsync(loginRequest);
        
        return authResponse?.IsSuccessful == true 
            ? Ok(authResponse) 
            : Unauthorized(authResponse);
    }
}