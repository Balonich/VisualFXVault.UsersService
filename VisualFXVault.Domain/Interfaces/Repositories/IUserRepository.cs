using VisualFXVault.Domain.Entities;

namespace VisualFXVault.Domain.Interfaces.Repositories;

/// <summary>
/// Interface for user repository to manage user-related data operations.
/// This interface defines methods for adding a user, retrieving a user by ID,
/// and retrieving a user by email and password.
/// <br/>
/// NOTE: It is a part of the Domain layer to follow the Clean Architecture principles.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Asynchronously adds a new user to the repository.
    /// </summary>
    /// <param name="user">The user to be added.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the added user 
    /// with corresponding User ID, or null if no user is created.
    /// </returns>
    Task<ApplicationUser?> AddUserAsync(ApplicationUser user);

    /// <summary>
    /// Asynchronously retrieves a user by their unique identifier.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the user
    /// with the specified ID, or null if no user is found.
    /// </returns>
    Task<ApplicationUser?> GetUserByIdAsync(Guid userId);

    /// <summary>
    /// Asynchronously retrieves a user by their email and password.
    /// </summary>
    /// <param name="email">The email of the user.</param>
    /// <param name="password">The password of the user.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the user
    /// with the specified email and password, or null if no user is found.
    /// </returns>
    Task<ApplicationUser> GetUserByEmailAndPasswordAsync(string email, string password);
}