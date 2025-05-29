using Application.Interfaces;
using Contracts.Users.Response;
using Domain.Users;

namespace Application.Features.Users.CreateUser
{
    public class CreateUserCommandHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        public CreateUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<CreateUserResponse?> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            UserFullName fullName = new(command.FirstName, command.SecondName, command.LastName);
            UserEmail userEmail = new(command.Email);

            var hashPassword = _passwordHasher.HashContent(command.Password);
            UserCredential credential = new(hashPassword, null);
            User user = new(
                id: Guid.NewGuid(),
                fullName: fullName,
                credential: credential,
                email: userEmail
            );
            await _userRepository.CreateUserAsync(user, cancellationToken);

            CreateUserResponse userResponse = new()
            {
                Id = user.Id.ToString(),
                FirstName = user.FullName.FirstName,
                LastName = user.FullName.LastName,
                Email = user.Email.Value
            };
            return userResponse;
        }

    }
}