// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE file in the project root for license information.

namespace Evolve.Data;

/// <inheritdoc />
public class Connection : IConnection
{
    /// <inheritdoc />
    public IConnectionFactory ConnectionFactory { get; set; } = null!;
}