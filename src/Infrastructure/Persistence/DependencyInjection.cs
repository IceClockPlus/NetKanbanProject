namespace Persistence
{
    using Application.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Configuration;
    using MongoDB.Driver;
    using Persistence.Repositories;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization;
    using MongoDB.Bson.Serialization.Serializers;

    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // Retrieve MongoDB connection string and database name from configuration
            var connectionString = configuration["MongoConnection:ConnectionString"];
            var databaseName = configuration["MongoConnection:DatabaseName"];

            if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(databaseName))
            {
                throw new ArgumentException("MongoDB connection string or database name is not configured.");
            }
        
            // Register MongoDB client connection
            services.AddSingleton<IMongoClient>(new MongoClient(connectionString));
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

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