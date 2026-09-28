using Microsoft.Data.SqlClient;

namespace POS.Repository;

public class DatabaseHelper
{
    private readonly IConfiguration _configuration;

    public DatabaseHelper(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<SqlConnection> OpenConnectionAsync()
    {
        string connectionString =
            _configuration.GetConnectionString("DefaultConnection");

        SqlConnection connection =
            new SqlConnection(connectionString);

        await connection.OpenAsync();

        return connection;
    }
}
