using System;
using System.Linq;
using AutoMapper;
using MovieStoreUI.Application.TokenOperations;
using MovieStoreUI.Common.Results;
using MovieStoreUI.DbOperations;
using MovieStoreUI.Entities;

namespace MovieStoreUI.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommand
    {
        public CreateCustomerViewModel Model { get; set; }
        
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateCustomerCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IResult Handle()
        {
            var customer = _dbContext.Customers.SingleOrDefault(customer =>customer.Email == Model.Email);
            if(customer is not null) return new ErrorResult("Kullanıcı Mevcut");
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(Model.Password, out passwordHash, out passwordSalt);
            
            customer = _mapper.Map<Customer>(Model);
            customer.PasswordHash = passwordHash;
            customer.PasswordSalt = passwordSalt;
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return new SuccessResult("Kayıt işlemi yapıldı");
        }
    }

     public class CreateCustomerViewModel
     {
         public string FirstName { get; set; }
         public string LastName { get; set; }
         public string Email { get; set; }
         public string Password { get; set; }
     }
}