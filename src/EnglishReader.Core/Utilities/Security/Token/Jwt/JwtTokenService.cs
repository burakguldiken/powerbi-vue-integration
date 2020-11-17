using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace EnglishReader.Core.Utilities.Security.Token.Jwt
{
    public class JwtTokenService : ITokenService
    {
        private readonly int _expiredHours = 24;
        private readonly string _secretKey = "EnglishReaderAsistant";

        public (DateTime expiredDate, string token) GenerateToken(long userId)
        {
            var someClaims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName,userId.ToString()),
            };
            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_secretKey));
            var token = new JwtSecurityToken(
                claims: someClaims,
                expires: DateTime.Now.AddHours(_expiredHours),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            );


            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            var expiredDate = DateTime.Now.AddHours(_expiredHours);

            return (expiredDate, tokenString);
        }
    }
}
