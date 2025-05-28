using Domain.Users;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        public Task<string> CreateUserAsync(User user, CancellationToken cancellationToken);
        public Task<User?> GetByIdAsync(string id, CancellationToken cancellationToken);
    }
}