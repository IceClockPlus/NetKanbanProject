
namespace Domain.Users
{
    public sealed class UserEmail : Domain.ValueObject.ValueObject
    {
        public string Value { get; } = string.Empty;
        public UserEmail(string value)
        {
            Value = value;
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }

}