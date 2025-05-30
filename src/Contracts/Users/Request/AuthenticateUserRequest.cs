namespace Contracts.Users.Request
{
    public record AuthenticateUserRequest
    {
        public required string Email { get; init; }
        public required string Password { get; init; }
    }
}