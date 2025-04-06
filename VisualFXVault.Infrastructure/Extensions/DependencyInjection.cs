using Microsoft.Extensions.DependencyInjection;
using VisualFXVault.Domain.Interfaces.Repositories;
using VisualFXVault.Infrastructure.DbContext;
using VisualFXVault.Infrastructure.Repositories;

namespace VisualFXVault.Infrastructure.Extensions;

public static class DependencyInjection
{
    /// <summary>
    /// Adds the infrastructure services to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<DapperDbContext>();

        return services;
    }
}