using System.Data;

namespace TaskAPI.Persistent.Data;

internal sealed class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    {
        var connection = new Microsoft.Data.SqlClient.SqlConnection(_connectionString);
        connection.Open();

        return connection;
    }
}