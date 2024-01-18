using HouseRentWebApi.ApplicationLogic.AccountLogic.Model;
using HouseRentWebApi.ApplicationLogic.JwtExtensionsLogic.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HouseRentWebApi.ApplicationLogic.JwtExtensionsLogic
{
    public static class JwtExtensions
    {
        public static string CreateJwt(UserModel userModel, JwtConfig jwtConfig)
        {
            var jwtTokenHendler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtConfig.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.NameId, userModel.Id),
                    new Claim(JwtRegisteredClaimNames.Email, userModel.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),

                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = jwtConfig.Issuer,
                Audience = jwtConfig.Audience
            };

            var token = jwtTokenHendler.CreateToken(tokenDescriptor);
            return jwtTokenHendler.WriteToken(token);
        }
    }
}