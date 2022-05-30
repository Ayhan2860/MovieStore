using System;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using MovieStoreUI.Application.TokenOperations;
using MovieStoreUI.Application.TokenOperations.Models;
using MovieStoreUI.Common.Results;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Application.CustomerOperations.Commands.CreateToken
{
    public class CreateTokenCommand
    {
        public CreateTokenModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContect;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;



        public CreateTokenCommand(IMovieStoreDbContext dbContect, IMapper mapper, IConfiguration configuration)
        {
            _dbContect = dbContect;
            _mapper = mapper;
            _configuration = configuration;
        }
        public IDataResult<Token> Handle()
        {
            var customer = _dbContect.Customers.SingleOrDefault(customer => customer.Email == Model.Email);
            
            if(customer is  null || !HashingHelper.VerifyPasswordHash(Model.Password, customer.PasswordHash, customer.PasswordSalt))
            {
                 return new ErrorDataResult<Token>("Kullancı Adı veya Şifre Hatalı");
            }
            
            else 
            {
                 TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(customer).Data;
                customer.RefreshToken = token.RefreshToken;
                customer.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _dbContect.SaveChanges();

                return new SuccessDataResult<Token>(token, "Access Token Oluşturuldu...");
            }
              
            
        }
    }
    public class CreateTokenModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}