using Dapper;

namespace TheDependencyProblem.Data;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(Guid id);
    Task<bool> CreateAsync(User user);
    Task<bool> DeleteByIdAsync(Guid id);
}

public class UserRepository : IUserRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public UserRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }
    
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        using var connection = await _connectionFactory.CreateDbConnectionAsync();
        return await connection.QueryAsync<User>("select * from Users");
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        const string query = "select * from Users where Id = @Id";
        using var connection = await _connectionFactory.CreateDbConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<User>(query, new { Id = id });
    }

    public async Task<bool> CreateAsync(User user)
    {
        const string query = "INSERT INTO Users (Id, FullName) VALUES (@Id, @FullName)";
        using var connection = await _connectionFactory.CreateDbConnectionAsync();
        var result = await connection.ExecuteAsync(query,
            new { user.Id, user.FullName });
        return result > 0;
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        const string query = "DELETE FROM Users where Id = @Id";
        using var connection = await _connectionFactory.CreateDbConnectionAsync();
        var result = await connection.ExecuteAsync(query, new { Id = id });
        return result > 0;
    }
}
