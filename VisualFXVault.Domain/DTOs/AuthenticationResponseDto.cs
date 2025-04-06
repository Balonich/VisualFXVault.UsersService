namespace VisualFXVault.Domain.DTOs;

public record AuthenticationResponseDto(
    Guid UserId,
    string? Email,
    string? Username,
    string? Gender,
    string? Token,
    bool IsSuccessful)
{
    // This constructor is used by AutoMapper to map from the entity to the DTO
    // without this constructor, AutoMapper would not be able to map the entity to the DTO
    // because the DTO does not have a parameterless constructor
    public AuthenticationResponseDto() : this(default, default, default, default, default, default)
    {
    }
}