using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.OrderOperations.Commands.UpdateOrder;
using Xunit;

namespace MovieStore.UnitTests.Applications.OrderOperations.OrderCommand
{
    public class UpdateOrderCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputOrderIdAreGiven_Validator_ShouldBeErrors()
        {
            //arrenge
            UpdateOrderCommand command = new UpdateOrderCommand(null);
            command.OrderId = 0;
            UpdateOrderValidator validator = new UpdateOrderValidator();
            //act
            var result = FluentActions.Invoking(()=> validator.Validate(command)).Invoke();
            //assert
            Assert.True(result.Errors.Count > 0);

        }

        [Fact]
        public void WhenValidInputOrderIdAreGiven_Validator_ShouldNotBeErrors()
        {
            //arrenge
            UpdateOrderCommand command = new UpdateOrderCommand(null);
            command.OrderId = 1;
            UpdateOrderValidator validator = new UpdateOrderValidator();
            //act
            var result = FluentActions.Invoking(()=> validator.Validate(command)).Invoke();
            //assert
             Assert.True(result.Errors.Count <= 0);


        }
    }
}