using System.Data;
using CorteAutomatico.Core.ApplicationModels;
using Npgsql;

namespace CorteAutomatico.Application.Configurations;

public static class DapperConfiguration
{
    public static void AddDapper(this IServiceCollection services)
    {
        EnvironmentVar envVar = new("DATABASE_CONNECTION_STRING");
        services.AddTransient<IDbConnection>((sp) => new NpgsqlConnection(envVar.ToString()));
    }
}