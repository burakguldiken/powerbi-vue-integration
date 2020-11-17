using EnglishReader.Business.Abstract;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EnglishReader.Business.Concrete
{
    public class JwtManager : IJwtService
    {
        public string CreateToken(string userId)
        {
            var someClaims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName,userId),
                new Claim(JwtRegisteredClaimNames.AuthTime,DateTime.Now.AddHours(3).ToString())
            };
            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("StackoverflowProject"));
            var token = new JwtSecurityToken(
                claims: someClaims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
