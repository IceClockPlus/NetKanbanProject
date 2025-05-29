namespace Contracts.Users.Response
{
    public record CreateUserResponse
    {
        public required string Id { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string Email { get; set; }
    }
}