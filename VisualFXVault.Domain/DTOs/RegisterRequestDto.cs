namespace VisualFXVault.Domain.DTOs;

public record RegisterRequestDto(
    string? Email,
    string? Password,
    string? Username,
    GenderOptions Gender);