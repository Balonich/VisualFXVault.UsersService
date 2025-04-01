namespace VisualFXVault.Domain.DTOs;

public record AuthenticationResponseDto(
    Guid UserId,
    string? Email,
    string? Username,
    string? Gender,
    string? Token,
    bool IsSuccessful);