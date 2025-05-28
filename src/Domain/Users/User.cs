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
        public string Id { get; private set; }
        public UserFullName FullName { get; private set; }
        public UserEmail Email { get; private set; }
        public UserCredential Credential { get; private set; }
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        public string? AvatarUrl { get; init; }

        public User(string id, UserFullName fullName, UserCredential credential, UserEmail email)
        {
            Id = id;
            FullName = fullName;
            Credential = credential;
            Email = email;
        }
    }
}
