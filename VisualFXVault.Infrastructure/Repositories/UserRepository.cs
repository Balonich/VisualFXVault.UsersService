using Dapper;
using VisualFXVault.Domain.DTOs;
using VisualFXVault.Domain.Entities;
using VisualFXVault.Domain.Interfaces.Repositories;
using VisualFXVault.Infrastructure.DbContext;

namespace VisualFXVault.Infrastructure.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly DapperDbContext _dbContext;

    public UserRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ApplicationUser?> AddUserAsync(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();

        var rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(DapperSqlQueries.UserQueries.Insert, user);

        if (rowCountAffected == 0)
        {
            return null;
        }

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
        var user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(
            DapperSqlQueries.UserQueries.GetByEmailAndPassword,
            new { email, password });

        if (user == null || user == default(ApplicationUser))
        {
            return null;
        }
        
        return user;
    }
}