namespace Contracts.Users.Request
{
    public record CreateUserRequest
    {
        public required string FirstName { get; init; }
        public string? SecondName { get; init; }
        public required string LastName { get; init; }
        public required string Email { get; init; }
        public required string Password { get; init; }
    }
}