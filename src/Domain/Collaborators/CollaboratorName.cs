using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Collaborators
{
    public class CollaboratorName : Domain.ValueObject.ValueObject
    {
        public string FirstName { get; private set; }
        public string? SecondName { get; private set; }
        public string LastName { get; private set; }
        public CollaboratorName(string firstName, string? secondName, string lastName)
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
