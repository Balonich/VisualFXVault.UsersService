using Microsoft.Extensions.DependencyInjection;

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
        return services;
    }
}