using Domain.ValueObject;
namespace Domain.Users
{
    public sealed class UserFullName : Domain.ValueObject.ValueObject
    {
        public string FirstName { get; }
        public string? SecondName { get;  }
        public string LastName { get; }

        public UserFullName(string firstName, string? secondName, string lastName)
        {
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FirstName;
            yield return SecondName ?? string.Empty;
            yield return LastName;
        }
    }
}