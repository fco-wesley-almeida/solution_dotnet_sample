using System;
using CorteAutomatico.Core.DatabaseContext;
using CorteAutomatico.Tests.DatabasePreConditions;
using Microsoft.EntityFrameworkCore;

// using ServiceCollectionExtensions;
namespace CorteAutomatico.Tests.Fixtures;

public class TestDatabaseFixture
{
    public const string ConnectionString = "Host=se.m01;Database=se_d02;Username=admin;Password=admin;Pooling=true";

    private static readonly object Lock = new();
    private static bool _databaseInitialized;

    public TestDatabaseFixture()
    {
        ConfigureEnvironment();
        CreatePreConditionsForTesting();
    }
    private static void ConfigureEnvironment()
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "TESTS");
        Environment.SetEnvironmentVariable("TESTS_DATABASE_CONNECTION_STRING", ConnectionString);
    }

    private static void CreatePreConditionsForTesting()
    {
        lock (Lock)
        {
            if (_databaseInitialized) return;
            using (var context = new CorteAutomaticoContext())
            {
                context.Database.EnsureDeleted();
                context.Database.Migrate();
                context.Database.EnsureCreated();
                PreConditionsSeeder.CreatePreConditions(context);
                context.SaveChanges();
            }
            _databaseInitialized = true;
        }
    }
}