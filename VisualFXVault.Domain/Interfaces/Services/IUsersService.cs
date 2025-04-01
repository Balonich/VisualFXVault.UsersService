using VisualFXVault.Domain.DTOs;

namespace VisualFXVault.Domain.Interfaces.Services;

/// <summary>
/// Interface for user service that contains use cases for users.
/// </summary>
public interface IUsersService
{
    /// <summary>
    /// Method to handle user register use case.
    /// </summary>
    /// <param name="registerRequest">The registration request object.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the authentication response object.
    /// Contains status of registration attempt and user information if successful.
    /// </returns>
    Task<AuthenticationResponseDto?> RegisterAsync(RegisterRequestDto registerRequest);

    /// <summary>
    /// Method to handle user login use case.
    /// </summary>
    /// <param name="loginRequestDto">The login request object.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the authentication response object.
    /// Contains status of login attempt and user information if successful.
    /// </returns>
    Task<AuthenticationResponseDto?> LoginAsync(LoginRequestDto loginRequest);
}