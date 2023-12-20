using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace service.AppServices
{


    public class JwtService
    {
        public static (string token, DateTime expires) GenerateJwtToken(string secretKey, string subject,
           string issuer, string audience, int validTimeInMinute, Guid id)
        {
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim(ClaimTypes.Name, id.ToString()),
                    };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddMinutes(validTimeInMinute);
            var jwtToken = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: expires,
                signingCredentials: signIn);
            return (new JwtSecurityTokenHandler().WriteToken(jwtToken), expires);
        }
       

    }
}
