// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE file in the project root for license information.

namespace Evolve.Data.Tests;

public class EvolveDataAccessExtensionsTests
{
    [Fact]
    public void AddEvolveDataAccess_ThrowsAnExceptionForNullServices()
    {
        // Arrange
        IServiceCollection services = null!;

        // Act and Assert
        var exception = Assert.Throws<ArgumentNullException>(() => services.AddEvolveDataAccess());

        Assert.Equal("services", exception.ParamName);
    }
}