namespace Application.Features.Users.CreateUser
{
    public class CreateUserCommand
    {
        public required string FirstName { get; set; }
        public string? SecondName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}