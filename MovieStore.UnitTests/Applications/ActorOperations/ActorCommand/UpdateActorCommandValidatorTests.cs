using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.ActorOperations.Commands.UpdateActor;
using Xunit;

namespace MovieStore.UnitTests.Applications.ActorOperations.ActorCommand
{
    public class UpdateActorCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("", "")]
         public void WhenInvalidInputActorIdAreGiven_Validator_ShouldBeReturnErrors(string firstName, string lastName)
         {
            // arrenge
             UpdateActorCommand command = new UpdateActorCommand(null);
             command.ActorId = 2;
             command.Model = new UpdateActorViewModel
             {
                 FirstName = firstName,
                 LastName = lastName
             };
             
             //act
             UpdateActorValidator validator = new UpdateActorValidator();
             var result = validator.Validate(command);

             // assert
             result.Errors.Count.Should().BeGreaterThan(0);

         }

         [Fact]
         public void WhenValidInputAuthorIdAreGiven_Validator_ShouldNotBeReturnErrors()
         {
              // arrenge
             UpdateActorCommand command = new UpdateActorCommand(null);
             command.ActorId = 2;
             command.Model = new UpdateActorViewModel
             {
                 FirstName = "Hatice",
                 LastName = "Karaman"
             };
             
             //act
             UpdateActorValidator validator = new UpdateActorValidator();
             var result = validator.Validate(command);

             // assert
            result.Errors.Count.Should().Be(0);
            
         }
    }
}