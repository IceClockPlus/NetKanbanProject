namespace Persistence
{
    using Application.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    using MongoDB.Driver;
    using Persistence.Repositories;

    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString, string databaseName)
        {
            // Register MongoDB client connection
            services.AddSingleton<IMongoClient>(new MongoClient(connectionString));

            // Register MongoDB database
            services.AddSingleton<IMongoDatabase>(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase(databaseName);
            });
           

            services.AddScoped<IBoardRepository, BoardRepository>();

            return services;
        }
    }
}