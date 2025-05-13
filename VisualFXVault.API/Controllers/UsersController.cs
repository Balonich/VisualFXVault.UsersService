using Microsoft.AspNetCore.Mvc;
using VisualFXVault.Domain.Interfaces.Services;

namespace VisualFXVault.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserById(Guid userId)
    {
        if (userId == Guid.Empty)
        {
            return BadRequest("Invalid user ID.");
        }

        var userResponse = await _usersService.GetUserByIdAsync(userId);

        return userResponse != null ? Ok(userResponse) : NotFound(userResponse);
    }
}