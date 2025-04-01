namespace VisualFXVault.Domain.DTOs;

public record LoginRequestDto(
    string? Email,
    string? Password);