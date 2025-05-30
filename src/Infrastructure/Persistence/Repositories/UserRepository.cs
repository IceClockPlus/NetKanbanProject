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

        public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var user = await _userCollection.Find(u => u.Id == id).FirstOrDefaultAsync(cancellationToken);
            return user?.ToDomain();
        }

        public async Task<Guid> CreateUserAsync(User user, CancellationToken cancellationToken)
        {
            var userDocument = user.ToDocument();
            await _userCollection.InsertOneAsync(userDocument, cancellationToken: cancellationToken);
            return user.Id;
        }

        /// <summary>
        /// Method to get the user by its email
        /// </summary>
        /// <param name="email"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
        {
            var user = await _userCollection.Find(u => u.Email == email).FirstOrDefaultAsync();
            return user?.ToDomain();
        }
    }
}