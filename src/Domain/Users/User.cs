namespace Domain.Users
{
    /// <summary>
    /// Represents a user in the system.
    /// This class is used to manage user details, such as their ID, name, and other relevant information.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Represents the unique identifier for the user.
        /// This property is required and must be initialized when creating a new user.
        /// </summary>
        public required string Id { get; init; }
        public required string FirstName { get; init; }
        public string? SecondName { get; init; }
        public required string LastName { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        public string? AvatarUrl { get; init; }
    }
}
