using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace VisualFXVault.Infrastructure.DbContext;

public class DapperDbContext
{
    private readonly IConfiguration _configuration;
    private readonly IDbConnection _connection;

    public DapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration;

        var connectionStringTemplate = _configuration.GetConnectionString("PostgresConnection");

        if (string.IsNullOrEmpty(connectionStringTemplate))
        {
            throw new ArgumentNullException("Connection string is not configured in appsettings.json");
        }

        var connectionString = connectionStringTemplate
            .Replace("$POSTGRES_HOST", Environment.GetEnvironmentVariable("POSTGRES_HOST"))
            .Replace("$POSTGRES_PASSWORD", Environment.GetEnvironmentVariable("POSTGRES_PASSWORD"));

        _connection = new NpgsqlConnection(connectionString);
    }

    public IDbConnection DbConnection => _connection;
}