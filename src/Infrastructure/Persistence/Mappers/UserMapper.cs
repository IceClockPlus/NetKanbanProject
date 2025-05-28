using System.Reflection.Metadata;
using Domain.Users;
using Persistence.Entities;

namespace Persistence.Mappers
{
    public static class UserMapper
    {
        public static UserDocument ToDocument(this User user)
        {
            return new UserDocument
            {
                Id = user.Id,
                Name = user.FullName.FirstName,
                SecondName = user.FullName.SecondName,
                LastName = user.FullName.LastName,
                CreatedAt = user.CreatedAt,
                Email = user.Email.Value,
                UserCredetials = new()
                {
                    Password = user.Credential.Password,
                    Salt = user.Credential.Salt,
                    LastUpdate = user.Credential.LastChange
                }
            };
        }

        public static User ToDomain(this UserDocument document)
        {
            UserCredential credential = new(
                document.UserCredetials.Password,
                document.UserCredetials.Salt,
                document.UserCredetials.LastUpdate
            );
            UserFullName userFullName = new(
                firstName: document.Name,
                secondName: document.SecondName,
                lastName: document.LastName
            );
            UserEmail userEmail = new(document.Email);
            return new User(
                id: document.Id,
                fullName: userFullName,
                credential: credential,
                email: userEmail
            );

        }
    }
}