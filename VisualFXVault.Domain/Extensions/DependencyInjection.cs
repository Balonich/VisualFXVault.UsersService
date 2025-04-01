using Microsoft.Extensions.DependencyInjection;
using VisualFXVault.Domain.Interfaces.Services;
using VisualFXVault.Domain.Services;

namespace VisualFXVault.Domain.Extensions;

public static class DependencyInjection
{
    /// <summary>
    /// Adds the domain services to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddScoped<IUsersService, UsersService>();

        return services;
    }
}