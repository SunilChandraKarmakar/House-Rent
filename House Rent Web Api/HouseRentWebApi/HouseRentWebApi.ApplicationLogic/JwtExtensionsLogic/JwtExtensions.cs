using HouseRentWebApi.ApplicationLogic.AccountLogic.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HouseRentWebApi.ApplicationLogic.JwtExtensionsLogic
{
    public static class JwtExtensions
    {
        public static string CreateJwt(UserModel userModel)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("top security key..."));
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, userModel.UserName),
                new Claim(ClaimTypes.NameIdentifier, userModel.Id.ToString())
            };

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = signingCredentials
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var createToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);

            return jwtSecurityTokenHandler.WriteToken(createToken);
        }
    }
}