using System.Threading.Tasks;
using Application.Interfaces;
using Contracts.Users.Response;
using Domain.Users;

namespace Application.Features.Users.AuthenticateUser
{
    public class AuthenticateUserCommandHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticateUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<AuthenticatedUserResponse?> Handle(AuthenticateUserCommand command, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetUserByEmailAsync(command.Email, cancellationToken);
            if (user == null)
            {
                return null;
            }

            bool isPasswordVerified = _passwordHasher.Verify(user.Credential.Password, command.Password);
            if (!isPasswordVerified) return null;
            return new()
            {
                Id = user.Id.ToString(),
                FirstName = user.FullName.FirstName,
                SecondName = user.FullName.SecondName,
                LastName = user.FullName.LastName,
                Email = user.Email.Value
            };
        }
    }
}
