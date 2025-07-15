using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Users.Request
{
    public record UpdateUserAccountRequest
    {
        public string FirstName { get; init; } = string.Empty;
        public string? SecondName { get; init; }
        public string LastName { get; init; } = string.Empty;

    }
}
