using Contracts.Users.Response;

namespace API.Helpers.Authentication
{
    public interface IAuthorizationService
    {
        string GenerateAccessToken(AuthenticatedUserResponse user);
    }
}