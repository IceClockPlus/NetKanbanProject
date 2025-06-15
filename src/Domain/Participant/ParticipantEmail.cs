
namespace Domain.Participant
{
    public class ParticipantEmail : Domain.ValueObject.ValueObject
    {
        public string Value { get; private set; } = string.Empty;
        public ParticipantEmail(string email)
        {
            Value = email;
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}