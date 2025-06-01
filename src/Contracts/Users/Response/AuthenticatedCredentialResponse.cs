namespace Contracts.Users.Response
{
    /// <summary>
    /// Record for credentials for the authentication flow
    /// </summary>
    public record AuthenticatedCredentialResponse
    {
        /// <summary>
        /// Access token to which the user can access to system functions
        /// </summary>
        public required string AccessToken { get; init; }

        /// <summary>
        /// Refresh token to renew its expired access token
        /// </summary>
        public string? RefreshToken { get; init; }
    }
}