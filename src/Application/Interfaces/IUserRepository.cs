using Domain.Users;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        public Task<Guid> CreateUserAsync(User user, CancellationToken cancellationToken);
        public Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        public Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
    }
}