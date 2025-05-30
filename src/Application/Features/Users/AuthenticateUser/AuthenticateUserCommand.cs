namespace Application.Features.Users.AuthenticateUser
{
    public class AuthenticateUserCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public AuthenticateUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}