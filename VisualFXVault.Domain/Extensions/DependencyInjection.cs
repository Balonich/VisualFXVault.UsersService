using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using VisualFXVault.Domain.Interfaces.Services;
using VisualFXVault.Domain.Services;
using VisualFXVault.Domain.Validators;

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

        // Register FluentValidation validators
        // This will scan the assembly for all classes that implement IValidator<T> and register them
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

        return services;
    }
}