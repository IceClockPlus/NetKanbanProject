namespace Persistence.Entities
{
    public class UserDocument
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserCredetialsDocument UserCredetials { get; set; }
    }

    public class UserCredetialsDocument
    {
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}