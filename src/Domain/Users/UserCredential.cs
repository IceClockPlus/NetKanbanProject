
namespace Domain.Users
{
    public sealed class UserCredential : Domain.ValueObject.ValueObject
    {
        public required string Password { get; init; }
        public required string Salt { get; init; }
        public DateTime? LastChange { get; private set; }

        public UserCredential(string password, string salt, DateTime? lastChange)
        {
            Password = password;
            Salt = salt;
            LastChange = lastChange;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Password;
            yield return Salt;
        }
    }
}