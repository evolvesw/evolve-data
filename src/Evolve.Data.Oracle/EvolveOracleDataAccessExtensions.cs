// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE file in the project root for license information.

using Oracle.ManagedDataAccess.Client;

namespace Evolve.Data.Oracle;

/// <summary>
/// Extension methods for <see cref="IConnection"/> to configure Oracle.
/// </summary>
public static class EvolveOracleDataAccessExtensions
{
    /// <summary>
    /// Configures to connect to an Oracle database.
    /// </summary>
    /// <param name="connection">The connection.</param>
    /// <param name="connectionString">The connection string of the database to connect to.</param>
    /// <returns>The <see cref="IConnection"/> so that additional calls can be chained.</returns>
    /// <exception cref="ArgumentNullException">The connection is null.</exception>
    /// <exception cref="ArgumentNullException">The connectionString is null.</exception>
    public static IConnection UseOracle(this IConnection connection, string connectionString)
    {
        if (connection == null)
        {
            throw new ArgumentNullException(nameof(connection));
        }

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new ArgumentNullException(nameof(connectionString));
        }

        connection.ConnectionFactory = new ConnectionFactory<OracleConnection>(connectionString);

        return connection;
    }
}