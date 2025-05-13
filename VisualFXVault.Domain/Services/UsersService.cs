using AutoMapper;
using VisualFXVault.Domain.DTOs;
using VisualFXVault.Domain.Entities;
using VisualFXVault.Domain.Interfaces.Repositories;
using VisualFXVault.Domain.Interfaces.Services;

namespace VisualFXVault.Domain.Services;

internal class UsersService : IUsersService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UsersService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<AuthenticationResponseDto?> RegisterAsync(RegisterRequestDto registerRequest)
    {
        var user = _mapper.Map<ApplicationUser>(registerRequest);

        var registeredUser = await _userRepository.AddUserAsync(user);

        if (registeredUser == null)
        {
            return null;
        }

        return _mapper.Map<AuthenticationResponseDto>(registeredUser) with
        {
            IsSuccessful = true,
            Token = "token"
        };
    }

    public async Task<AuthenticationResponseDto?> LoginAsync(LoginRequestDto loginRequest)
    {
        var user = await _userRepository.GetUserByEmailAndPasswordAsync(loginRequest.Email, loginRequest.Password);

        if (user == null)
        {
            return null;
        }

        return _mapper.Map<AuthenticationResponseDto>(user) with
        {
            IsSuccessful = true,
            Token = "token"
        };
    }

    public async Task<UserResponseDto?> GetUserByIdAsync(Guid userId)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);

        if (user == null)
        {
            return null;
        }

        return _mapper.Map<UserResponseDto>(user);
    }
}