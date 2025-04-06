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
        var connectionString = _configuration.GetConnectionString("PostgresConnection");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentNullException("Connection string is not configured in appsettings.json");
        }

        _connection = new NpgsqlConnection(connectionString);
    }
    
    public IDbConnection DbConnection => _connection;
}