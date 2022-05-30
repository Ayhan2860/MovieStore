using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.CustomerOperations.Commands.CreateCustomer;
using Xunit;

namespace MovieStore.UnitTests.Applications.CustomerOperations.CustomerCommand
{
    public class CreateCustomerCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("", "", "", "")]
        [InlineData("ay", "ka", "ayhan", "1234")]
        public void WhenInvalidInputCustomerAreGiven_Validator_ShouldBeReturnErrors
        (string firstName, string lastName, string email, string password)
        {
             //arrenge
            CreateCustomerCommand command = new CreateCustomerCommand(null, null);
            command.Model = new CreateCustomerViewModel
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
             
             //act
             CreateCustomerValidation validator = new CreateCustomerValidation();
             var result = validator.Validate(command);

             //assert
             result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenInvalidInputCustomerAreGiven_Validator_ShouldNotBeReturnErrors()
        {
             //arrenge
            CreateCustomerCommand command = new CreateCustomerCommand(null, null);
            command.Model = new CreateCustomerViewModel
            {
                FirstName = "Yasin",
                LastName = "Şahin",
                Email = "yasin@gmail.com",
                Password = "123456"
            };
             
             //act
             CreateCustomerValidation validator = new CreateCustomerValidation();
             var result = validator.Validate(command);

             //assert
             result.Errors.Count.Should().Be(0);
        }
    }
}