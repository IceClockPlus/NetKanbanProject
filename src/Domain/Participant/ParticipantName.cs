
namespace Domain.Participant
{
    public class ParticipantName : Domain.ValueObject.ValueObject
    {
        public string FirstName { get; private set; }
        public string? SecondName { get; private set; }
        public string LastName { get; private set; }

        public ParticipantName(string firstName, string? secondName, string lastName)
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