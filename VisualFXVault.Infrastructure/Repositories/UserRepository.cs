using VisualFXVault.Domain.DTOs;
using VisualFXVault.Domain.Entities;
using VisualFXVault.Domain.Interfaces.Repositories;

namespace VisualFXVault.Infrastructure.Repositories;

internal class UserRepository : IUserRepository
{
    public UserRepository()
    {
    }

    public async Task<ApplicationUser?> AddUserAsync(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();
        // TODO: Add user to the database using Dapper

        return user;
    }

    public async Task<ApplicationUser?> GetUserByIdAsync(Guid userId)
    {
        // TODO: This is a mock implementation. Replace with actual database call.
        return new ApplicationUser()
        {
            UserId = userId,
            Email = "some-email@gmail.com",
            Password = "alalapass",
            Username = "Some name",
            Gender = GenderOptions.Male.ToString()
        };
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPasswordAsync(string email, string password)
    {
        // TODO: This is a mock implementation. Replace with actual database call.
        return new ApplicationUser()
        {
            UserId = Guid.NewGuid(),
            Email = email,
            Password = password,
            Username = "Some name",
            Gender = GenderOptions.Male.ToString()
        };
    }
}