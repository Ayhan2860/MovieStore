using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using MovieStoreUI.Application.TokenOperations;
using MovieStoreUI.Application.TokenOperations.Models;
using MovieStoreUI.Common.Results;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Application.CustomerOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
        public string RefreshToken { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public RefreshTokenCommand(IMovieStoreDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public IDataResult<Token> Handle()
        {
            var customer = _dbContext.Customers.SingleOrDefault(customer=>customer.RefreshToken == RefreshToken && customer.RefreshTokenExpireDate > DateTime.Now);
            if (customer is not null)
            {
                TokenHandler tokenHandler = new TokenHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken(customer).Data;
                
                customer.RefreshToken = token.RefreshToken;
                customer.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                
                _dbContext.SaveChanges();

                return new SuccessDataResult<Token>(token);
            }else
                return new ErrorDataResult<Token>("Geçerli bir refresh token bulunamadı");
        }
    }
}