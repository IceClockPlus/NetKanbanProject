
namespace Domain.Users
{
    public sealed class UserCredential : Domain.ValueObject.ValueObject
    {
        public string Password { get; private set; }
        public DateTime? LastChange { get; private set; }

        public UserCredential(string password, DateTime? lastChange)
        {
            Password = password;
            LastChange = lastChange;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Password;
        }
    }
}