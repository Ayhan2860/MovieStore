using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MovieStoreUI.Application.TokenOperations.Models;
using MovieStoreUI.Common.Results;
using MovieStoreUI.Entities;

namespace MovieStoreUI.Application.TokenOperations
{
    public class TokenHandler
    {
        public IConfiguration Configuration { get; set; }
        public TokenHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IDataResult<Token> CreateAccessToken(Customer customer)
        {
            Token tokenModel = new Token();
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenOptions:SecurityKey"]));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            tokenModel.Expiration = DateTime.Now.AddMinutes(15);
            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer:Configuration["TokenOptions:Issuer"],
                audience:Configuration["TokenOptions:Audience"],
                expires:tokenModel.Expiration,
                notBefore:DateTime.Now,
                signingCredentials:credentials
            );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            tokenModel.AccessToken = tokenHandler.WriteToken(securityToken);
            tokenModel.RefreshToken = CreateRefreshToken();
             
            return new SuccessDataResult<Token>(tokenModel);
        }

        public string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}