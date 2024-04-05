using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EcommerceAPI.Dominio.Services.JWT
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration _configuration;

        public JWTService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerarToken()
        {
            var claims = new[]
            {
               //new Claim(ClaimTypes.Email, email),
               //new Claim(ClaimTypes.NameIdentifier, id.ToString()),
               new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"])
           };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"]
                , _configuration["Jwt:Audience"]
                , claims
                , expires: DateTime.Now.AddMinutes(int.Parse(_configuration["Jwt:ExpireTime"])),
                signingCredentials: signIn
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
