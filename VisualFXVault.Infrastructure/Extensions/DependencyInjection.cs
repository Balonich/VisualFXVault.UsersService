using Microsoft.Extensions.DependencyInjection;

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
        return services;
    }
}