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
        public Guid Id { get; private set; }
        public UserFullName FullName { get; private set; }
        public UserEmail Email { get; private set; }
        public UserCredential Credential { get; private set; }
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        public string? AvatarUrl { get; init; }
        public bool IsEnabled { get; private set; }

        public bool SetFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                return false;
            }
            FullName = new UserFullName(firstName, FullName.SecondName, FullName.LastName);
            return true;
        }

        public bool SetSecondName(string? secondName)
        {
            FullName = new UserFullName(FullName.FirstName, secondName, FullName.LastName);
            return true;
        }

        public bool SetLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                return false;
            }
            FullName = new UserFullName(FullName.FirstName, FullName.SecondName, lastName);
            return true;
        }

        /// <summary>
        /// Enable the user account.
        /// </summary>
        public void EnableUser()
        {
            IsEnabled = true;
        }

        /// <summary>
        /// Disable the user account.
        /// </summary>
        public void DisableUser()
        {
            IsEnabled = false;
        }

        public User(Guid id, UserFullName fullName, UserCredential credential, UserEmail email, bool isEnabled)
        {
            Id = id;
            FullName = fullName;
            Credential = credential;
            Email = email;
            IsEnabled = isEnabled;
        }
    }
}
