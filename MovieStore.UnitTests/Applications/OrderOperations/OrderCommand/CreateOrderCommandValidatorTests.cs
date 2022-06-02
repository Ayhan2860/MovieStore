using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.OrderOperations.Commands.CreateOrder;
using Xunit;

namespace MovieStore.UnitTests.Applications.OrderOperations.OrderCommand
{
    public class CreateOrderCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Fact]
       public void WhenInvalidInputOrderAreGiven_Validator_ShouldBeErrors()
       {
            CreateOrderCommand command = new CreateOrderCommand(null, null);
            command.Model = new CreateOrderViewModel
            {
                CustomerId = 0,
                MovieId = 0,
            };
            CreateOrderValidator validator = new CreateOrderValidator();
            //act
            var result = FluentActions.Invoking(()=> validator.Validate(command)).Invoke();
            //act
            Assert.True(result.Errors.Count > 0);
       }
        [Fact]
       public void WhenValidInputOrderAreGiven_Validator_ShouldNotBeErrors()
       {
            CreateOrderCommand command = new CreateOrderCommand(null, null);
            command.Model = new CreateOrderViewModel
            {
                CustomerId = 2,
                MovieId = 3
            };
            CreateOrderValidator validator = new CreateOrderValidator();
            //act
            var result = FluentActions.Invoking(()=> validator.Validate(command)).Invoke();
            //act
            Assert.True(result.Errors.Count <= 0);
       }
    }
}