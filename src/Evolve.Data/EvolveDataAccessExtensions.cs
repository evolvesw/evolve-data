// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE file in the project root for license information.

using Evolve.Data;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for adding Evolve services to the <see cref="IServiceCollection"/>.
/// </summary>
public static class EvolveDataAccessExtensions
{
    /// <summary>
    /// Adds the Evolve data access services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
    /// <param name="optionsAction">The <see cref="IConnection"/> options to configure the services.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddEvolveDataAccess(this IServiceCollection services, Action<IConnection>? optionsAction = null)
    {
        return services == null
            ? throw new ArgumentNullException(nameof(services))
            : AddEvolveDataAccess(
            services,
            optionsAction == null
                ? null
                : (_, c) => optionsAction(c));
    }

    /// <summary>
    /// Adds the Evolve data access services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
    /// <param name="optionsAction">The <see cref="IConnection"/> options to configure the services.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddEvolveDataAccess(this IServiceCollection services, Action<IServiceProvider, IConnection>? optionsAction)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.TryAdd(
            new ServiceDescriptor(
                typeof(IConnection),
                c => ConnectionFactory(c, optionsAction),
                ServiceLifetime.Singleton));

        return services;
    }

    private static IConnection ConnectionFactory(IServiceProvider serviceProvider, Action<IServiceProvider, IConnection>? optionsAction)
    {
        var connection = new Connection();
        optionsAction?.Invoke(serviceProvider, connection);

        return connection;
    }
}