using EasyBank.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EasyBank.Services
{
    public class JwtManager
    {
        private readonly IConfiguration _configuration;
        public JwtManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateAccessToken(Employee e)
        {
            var claims = new List<Claim>
            {
                new Claim("id", e.Id.ToString()),
                new Claim("name", e.FirstName),
                new Claim("surname", e.LastName),
                new Claim("position", e.Position),
                new Claim("role", e.Role),
                new Claim("phone", e.Phone),
                new Claim("address", e.Address)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = creds,
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
