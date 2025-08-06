
using NexCart.Users.Entities;
namespace NexCart.Users.RepositoryContracts;

public interface IUsersRepository
{
    Task<ApplicationUser?> AddUser(ApplicationUser user);
    Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);
    Task<ApplicationUser?> GetUserByUserId(Guid? userId);
}