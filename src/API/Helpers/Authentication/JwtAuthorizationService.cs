using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Contracts.Users.Response;
using Domain.Users;
using Microsoft.IdentityModel.Tokens;

namespace API.Helpers.Authentication
{
    public class JwtAuthorizationService : IAuthorizationService
    {
        private readonly string _issuer;
        private readonly string _audience;
        private readonly string _key;
        public JwtAuthorizationService(IConfiguration configuration)
        {
            _issuer = configuration["JwtSetting:Issuer"]!;
            _audience = configuration["JwtSetting:Audience"]!;
            _key = configuration["JwtSetting:Key"]!;
        }
        public string GenerateAccessToken(AuthenticatedUserResponse user)
        {
            var claims = new[]{
                new Claim(JwtRegisteredClaimNames.Name, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("Id", user.Id)
            };

            var secKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var creds = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(20),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}