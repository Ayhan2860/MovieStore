using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.ActorOperations.Commands.DeleteActor;
using Xunit;

namespace MovieStore.UnitTests.Applications.ActorOperations.ActorCommand
{
    public class DeleteActorCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
         [Theory]
         [InlineData(0)]
         [InlineData(null)]
         public void WhenInvalidInputActorIdAreGiven_Validator_ShouldBeErrors(int id)
         {
            // arrenge
             DeleteActorCommand command = new DeleteActorCommand(null);
             command.ActorId = id;
           
             //act
             DeleteActorValidator validator = new DeleteActorValidator();
             var result = validator.Validate(command);

             // assert
             result.Errors.Count.Should().BeGreaterThan(0);

         }

         [Fact]
         public void WhenValidInputActorIdAreGiven_Validator_ShouldNotBeReturnErrors()
         {
              // arrenge
             DeleteActorCommand command = new DeleteActorCommand(null);
             command.ActorId = 2;
             
            //act
             DeleteActorValidator validator = new DeleteActorValidator();
             var result = validator.Validate(command);

             // assert
             result.Errors.Count.Should().Be(0);
         }
    }
}