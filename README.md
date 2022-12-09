# Evolve Data

[![Build](https://github.com/evolvesw/evolve-data/actions/workflows/build.yml/badge.svg)](https://github.com/evolvesw/evolve-data/actions/workflows/build.yml)
[![NuGet Info](https://buildstats.info/nuget/Evolve.Data?includePreReleases=true)](https://www.nuget.org/packages/Evolve.Data/)
[![GitHub Release](https://img.shields.io/github/release/evolvesw/evolve-data.svg?logo=github&style=flat-square&color=blue)](https://github.com/evolvesw/evolve-data/releases)
[![License](https://img.shields.io/github/license/evolvesw/evolve-data?logo=apache&style=flat-square&color=blue)](LICENSE)

**Evolve data** is a lightweight database connectivity solution built over .NET.

## Usage

This sample shows how to use **Evolve.Data** to connect to a **Oracle** database.

1. Create a new table in the database.

```sql
CREATE TABLE "COMPANIES" 
(
    "ID"    NUMBER(10) NOT NULL,
    "NAME"  VARCHAR2(240) NOT NULL,
    CONSTRAINT "C_COMPANIES_PK" PRIMARY KEY ("ID")
);
/

INSERT INTO "COMPANIES" ("ID", "NAME") VALUES (1, 'Microsoft');
INSERT INTO "COMPANIES" ("ID", "NAME") VALUES (2, 'Apple');
INSERT INTO "COMPANIES" ("ID", "NAME") VALUES (3, 'Google');
INSERT INTO "COMPANIES" ("ID", "NAME") VALUES (4, 'Amazon');
INSERT INTO "COMPANIES" ("ID", "NAME") VALUES (5, 'Facebook');
INSERT INTO "COMPANIES" ("ID", "NAME") VALUES (6, 'Oracle');

COMMIT;
```

2. Create a new **.NET 7** console application.

```bash
dotnet new console --framework net7.0 -o Evolve.Data.Sample
```

3. Add the packages **Evolve.Data.Oracle** and **Dapper** to the project.

```bash
dotnet add package Evolve.Data.Oracle
dotnet add package Dapper
```

4. Add the following code to the **Program.cs** file.

```csharp
using Dapper;
using Evolve.Data;
using Evolve.Data.Oracle;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddEvolveDataAccess(options => options.UseOracle("User Id=user;Password=password;Data Source=127.0.0.1:1521/XE"));

var serviceProvider = services.BuildServiceProvider();

using var connection = serviceProvider.GetRequiredService<IConnection>().ConnectionFactory.CreateConnection();
connection.Open();

var companies = connection.Query<string>("SELECT NAME FROM COMPANIES");

Console.WriteLine($"Companies: {string.Join(", ", companies)}");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
```

We change the **User Id**, **Password** and **Data Source** to match our database.

5. Run the application.

```bash
dotnet run
```

## License

**Evolve Data** is **licensed** under the **[Apache 2.0]** license. The license is available [here](LICENSE).

[Apache 2.0]: https://www.apache.org/licenses/LICENSE-2.0