using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.ActorOperations.Commands.CreateActor;
using Xunit;

namespace MovieStore.UnitTests.Applications.ActorOperations.ActorCommand
{
    public class CreateActorCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        
        [Theory]
        [InlineData("", "")]
        public void WhenInvalidInputActorAreGiven_Validator_ShouldBeErrors(string firstName, string lastName)
        {
             //arrenge
             CreateActorCommand command = new CreateActorCommand(null, null);
             command.Model =  new CreateActorViewModel
             {
                 FirstName = firstName,
                 LastName  = lastName
             };
             //act
             CreateActorValidator validator = new CreateActorValidator();
             var result = validator.Validate(command);

             //assert
             //Assert.True(result.Errors.Count > 0);
              result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenValidInputActorIdAreGiven_Validator_ShouldNotBeReturnErrors()
        {    //arrenge
             CreateActorCommand command = new CreateActorCommand(null, null);
             command.Model =  new CreateActorViewModel
             {
                 FirstName = "Miraç",
                 LastName  = "Mert"
             };
             //act
             CreateActorValidator validator = new CreateActorValidator();
             var result = validator.Validate(command);

             //assert
            // Assert.True(result.Errors.Count == 0);
             result.Errors.Count.Should().Be(0);

        }
    }
}