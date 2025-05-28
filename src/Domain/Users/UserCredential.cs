
namespace Domain.Users
{
    public sealed class UserCredential : Domain.ValueObject.ValueObject
    {
        public string Password { get; private set; }
        public string Salt { get; private set; }
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