using Application.Interfaces;
using Domain.Users;
using MongoDB.Driver;
using Persistence.Entities;
using Persistence.Mappers;

namespace Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<UserDocument> _userCollection;
        public UserRepository(IMongoDatabase database)
        {
            _userCollection = database.GetCollection<UserDocument>("Users");
        }

        public async Task<User?> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            var user = await _userCollection.Find(u => u.Id == id).FirstOrDefaultAsync(cancellationToken);
            return user?.ToDomain();
        }

        public async Task<string> CreateUserAsync(User user, CancellationToken cancellationToken)
        {
            var userDocument = user.ToDocument();
            await _userCollection.InsertOneAsync(userDocument, cancellationToken: cancellationToken);
            return user.Id;
        }
    }
}