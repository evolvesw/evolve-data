// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE file in the project root for license information.

namespace Evolve.Data;

/// <summary>
/// Represents a factory for creating connections to a data source.
/// </summary>
public interface IConnectionFactory
{
    /// <summary>
    /// Creates a new <see cref="DbConnection"/> instance.
    /// </summary>
    DbConnection CreateConnection();

    /// <summary>
    /// Gets the type of the connection.
    /// </summary>
    Type DbConnectionType { get; }
}