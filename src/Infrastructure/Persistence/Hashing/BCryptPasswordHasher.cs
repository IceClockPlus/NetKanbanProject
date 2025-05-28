using Application.Interfaces;
using BCrypt.Net;

namespace Persistence.Hashing
{
    public class BCryptPasswordHasher : IPasswordHasher
    {
        public string HashContent(string content)
        {
            var hash = BCrypt.Net.BCrypt.HashPassword(content);
            return hash;
        }

        public bool Verify(string hash, string content)
        {
            return BCrypt.Net.BCrypt.Verify(content, hash);
        }
    }
}