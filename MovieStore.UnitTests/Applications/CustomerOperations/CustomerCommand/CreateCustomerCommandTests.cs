using System.Linq;
using AutoMapper;
using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.CustomerOperations.Commands.CreateCustomer;
using MovieStoreUI.DbOperations;
using MovieStoreUI.Entities;
using Xunit;

namespace MovieStore.UnitTests.Applications.CustomerOperations.CustomerCommand
{
    public class CreateCustomerCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateCustomerCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper  = fixture.Mapper;
        }
        
        [Fact]
        public void WhenAllReadyExistCustomerRegisterInfoGiven_ErrorResult_ShouldBeReturn()
        {
             //arrenge 
             //var customer = _context.Customers.SingleOrDefault(x=> x.Email == "ayhan@gmail.com");
             var customer =  new Customer{FirstName = "İlker", LastName = "Yigitalp", Email = "ilker@gmail.com"};
             _context.Customers.Add(customer);
             _context.SaveChanges();
             CreateCustomerCommand command  = new CreateCustomerCommand(_context, _mapper);
             command.Model = new CreateCustomerViewModel
             {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Password = "123456"
             };

             //act
             var result = FluentActions.Invoking(()=>command.Handle()).Invoke();

             //assert
             result.Message.Should().Be("Kullanıcı Mevcut");
             result.Success.Should().BeFalse();

        }


        [Fact]
        public void WhenAllReadyExistCustomerRegisterInfoGiven_Customer_ShouldBeRegister()
        {
             //arrenge 
             
             CreateCustomerCommand command  = new CreateCustomerCommand(_context, _mapper);
             command.Model = new CreateCustomerViewModel
             {
                FirstName = "İlker",
                LastName = "Yiğitalp",
                Email = "ilker@gmail.com",
                Password = "123456"
             };

             //act
             var result = FluentActions.Invoking(()=>command.Handle()).Invoke();

             //assert
             result.Message.Should().Be("Kayıt işlemi yapıldı");
             result.Success.Should().BeTrue();

        }

    }
}