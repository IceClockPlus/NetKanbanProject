namespace Application.Interfaces
{
    public interface IPasswordHasher
    {
        string HashContent(string content);
        bool Verify(string hash, string content);
    }
}