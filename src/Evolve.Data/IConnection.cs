// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE file in the project root for license information.

namespace Evolve.Data;

/// <summary>
/// A class implementing this interface represents a connection to a data source.
/// </summary>
public interface IConnection
{
    /// <summary>
    /// Gets or sets the <see cref="IConnectionFactory"/>.
    /// </summary>
    IConnectionFactory ConnectionFactory { get; set; }
}