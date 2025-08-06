using Microsoft.Extensions.DependencyInjection;
using NexCart.Users.Infrastructure.DbContext;
using NexCart.Users.Infrastructure.Repositories;
using NexCart.Users.RepositoryContracts;

namespace NexCart.Users.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IUsersRepository, UserRepository>();
        services.AddTransient<DapperDbContext>();
        return services;
    }
}