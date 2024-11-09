using System.Data;
using Microsoft.Data.Sqlite;

namespace TheDependencyProblem.Data;

public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateDbConnectionAsync();
}

public class MySqlDbConnectionFactory : IDbConnectionFactory
{
    public Task<IDbConnection> CreateDbConnectionAsync()
    {
        throw new NotImplementedException();
    }
}

public class SqliteDbConnectionFactory : IDbConnectionFactory
{
    private readonly DbConnectionOptions _connectionOptions;

    public SqliteDbConnectionFactory()
    {
        _connectionOptions = new DbConnectionOptions
        {
            ConnectionString = "Data Source=./database.db"
        };
    }

    public async Task<IDbConnection> CreateDbConnectionAsync()
    {
        var connection = new SqliteConnection(_connectionOptions.ConnectionString);
        await connection.OpenAsync();
        return connection;
    }
}
