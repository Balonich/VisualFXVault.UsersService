namespace VisualFXVault.Domain.Entities;

/// <summary>
/// Defines the ApplicationUser class which acts as entity
/// model class to sto user details in data store.
/// </summary>
public class ApplicationUser
{
    public Guid UserId { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Username { get; set; }
    public string? Gender { get; set; }
}