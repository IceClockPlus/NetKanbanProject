using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Collaborators
{
    public class CollaboratorEmail : Domain.ValueObject.ValueObject
    {
        public string Address { get; private set; }
        public CollaboratorEmail(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentException("Email cannot be null or empty.", nameof(address));
            }
            Address = address;
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Address;
        }
    }
}
