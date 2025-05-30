namespace Contracts.Users.Response
{
    public record AuthenticatedUserResponse
    {
        public required string Id { get; init; }
        public required string FirstName { get; init; }
        public string? SecondName { get; init; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
    }
}