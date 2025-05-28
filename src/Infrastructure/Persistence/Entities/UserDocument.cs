namespace Persistence.Entities
{
    public class UserDocument
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public string? SecondName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public required UserCredetialsDocument UserCredetials { get; set; }
    }

    public class UserCredetialsDocument
    {
        public required string Password { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}