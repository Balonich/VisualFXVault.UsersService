using VisualFXVault.Domain.DTOs;
using VisualFXVault.Domain.Entities;
using VisualFXVault.Domain.Interfaces.Repositories;
using VisualFXVault.Domain.Interfaces.Services;

namespace VisualFXVault.Domain.Services;

internal class UsersService : IUsersService
{
    private readonly IUserRepository _userRepository;

    public UsersService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<AuthenticationResponseDto?> RegisterAsync(RegisterRequestDto registerRequest)
    {
        var user = new ApplicationUser()
        {
            Email = registerRequest.Email,
            Password = registerRequest.Password,
            Username = registerRequest.Username,
            Gender = registerRequest.Gender.ToString()
        };

        var registeredUser = await _userRepository.AddUserAsync(user);

        if (registeredUser == null)
        {
            return null;
        }

        return new AuthenticationResponseDto(
            registeredUser.UserId,
            registeredUser.Email,
            registeredUser.Username,
            registeredUser.Gender,
            "token",
            IsSuccessful: true);
    }

    public async Task<AuthenticationResponseDto?> LoginAsync(LoginRequestDto loginRequest)
    {
        var user = await _userRepository.GetUserByEmailAndPasswordAsync(loginRequest.Email, loginRequest.Password);

        if (user == null)
        {
            return null;
        }

        return new AuthenticationResponseDto(
            user.UserId,
            user.Email,
            user.Username,
            user.Gender,
            "token",
            IsSuccessful: true);
    }
}