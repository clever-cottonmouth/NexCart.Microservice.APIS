﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using NexCart.Orders.Repositories;
using NexCart.Orders.RepositoryContracts;


namespace NexCart.Orders.Helpers
{
    public static class DADependencyInjection
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionStringTemplate =
                configuration.GetConnectionString("MongoDB")!;
            string connectionString = connectionStringTemplate.Replace("$MONGODB_HOST", Environment.GetEnvironmentVariable("MONGODB_HOST"))
                 .Replace("$MONGODB_PORT", Environment.GetEnvironmentVariable("MONGODB_PORT"));

            services.AddSingleton<IMongoClient>(new MongoClient(connectionString));

            services.AddScoped<IMongoDatabase>(provider =>
            {
                IMongoClient client = provider.GetRequiredService<IMongoClient>();
                return client.GetDatabase(Environment.GetEnvironmentVariable("MONGODB_DATABASE"));
            });

            services.AddScoped<IOrdersRepository, OrdersRepository>();

            return services;
        }
    }
}
