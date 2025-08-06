using Dapper;
using NexCart.Users.Entities;
using NexCart.Users.Infrastructure.DbContext;
using NexCart.Users.RepositoryContracts;

namespace NexCart.Users.Infrastructure.Repositories;


public class UserRepository : IUsersRepository
{
    private readonly DapperDbContext _dbContext;
    
    public UserRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();

        // Add user to database
        string query = "INSERT INTO public.\"Users\" (\"UserId\", \"Email\", \"PersonName\", \"Gender\", \"Password\") VALUES(@UserId, @Email, @PersonName, @Gender, @Password)";

        int rowCountAffected= await _dbContext.Connection.ExecuteAsync(query, user);
        if (rowCountAffected > 0)
        {
            return user;
        }
        else
        {
            return null;
        }
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        // Get user from database
        string query = "SELECT * FROM public.\"Users\" WHERE \"Email\" = @Email AND \"Password\" = @Password";

        var parameters = new { Email = email, Password = password };

        ApplicationUser? user = await _dbContext.Connection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);
        if (user == null)
        {
            return null;
        }
        else
        {
            return user;
        }
    }

    public async Task<ApplicationUser?> GetUserByUserId(Guid? userId)
    {
        // Get user from database
        string query = "SELECT * FROM public.\"Users\" WHERE \"UserId\" = @UserId";
        var parameters = new { UserId = userId };

        using var connection = _dbContext.Connection;
        return await connection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);
    }
}