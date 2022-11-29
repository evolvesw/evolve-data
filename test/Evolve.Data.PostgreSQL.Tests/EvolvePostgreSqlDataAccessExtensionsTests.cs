// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE file in the project root for license information.

using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Evolve.Data.PostgreSQL.Tests;

public class EvolvePostgreSqlDataAccessExtensionsTests
{
    private const string ConnectionString = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=postgres;";
    
    [Fact]
    public void UsePostgres_ThrowsAnExceptionForNullConnection()
    {
        // Arrange
        IConnection connection = null!;

        // Act and Assert
        var exception = Assert.Throws<ArgumentNullException>(() => connection.UsePostgreSql(ConnectionString));

        Assert.Equal("connection", exception.ParamName);
    }

    [Fact]
    public void UsePostgres_ThrowsAnExceptionForNullConnectionString()
    {
        // Arrange
        IConnection connection = Mock.Of<IConnection>();

        // Act and Assert
        var exception = Assert.Throws<ArgumentNullException>(() => connection.UsePostgreSql(null!));

        Assert.Equal("connectionString", exception.ParamName);
    }

    [Fact]
    public void AddEvolveDataAccess_RegisterPostgresDataAccess()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddEvolveDataAccess(c => c.UsePostgreSql(ConnectionString));

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var connection = serviceProvider.GetRequiredService<IConnection>();
        Assert.IsType<NpgsqlConnection>(connection.ConnectionFactory.CreateConnection());
    }
}