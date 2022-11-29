// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE file in the project root for license information.

using Microsoft.Extensions.DependencyInjection;
using Oracle.ManagedDataAccess.Client;

namespace Evolve.Data.Oracle.Tests;

public class EvolveOracleDataAccessExtensionsTests
{
    private const string ConnectionString = "User Id=system;Password=system;Data Source=localhost:1521/xe;";

    [Fact]
    public void UseOracle_ThrowsAnExceptionForNullConnection()
    {
        // Arrange
        IConnection connection = null!;

        // Act and Assert
        var exception = Assert.Throws<ArgumentNullException>(() => connection.UseOracle(ConnectionString));

        Assert.Equal("connection", exception.ParamName);
    }

    [Fact]
    public void UseOracle_ThrowsAnExceptionForNullConnectionString()
    {
        // Arrange
        IConnection connection = Mock.Of<IConnection>();

        // Act and Assert
        var exception = Assert.Throws<ArgumentNullException>(() => connection.UseOracle(null!));

        Assert.Equal("connectionString", exception.ParamName);
    }

    [Fact]
    public void AddEvolveDataAccess_RegisterOracleDataAccess()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddEvolveDataAccess(c => c.UseOracle(ConnectionString));

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var connection = serviceProvider.GetRequiredService<IConnection>();
        Assert.IsType<OracleConnection>(connection.ConnectionFactory.CreateConnection());
    }
}