using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.MovieOperations.Commands.DeleteMovie;
using Xunit;

namespace MovieStore.UnitTests.Applications.MovieOperations.MovieCommand
{
    public class DeleteMovieCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        
       [Theory]
       [InlineData(null)]
       public void WhenInvalidInputActorIdAreGiven_Validator_ShouldBeErrors(int id)
       {
           //arrenge
           DeleteMovieCommand command = new DeleteMovieCommand(null);
           command.MovieId  = id;
           DeleteMovieValidator validator = new DeleteMovieValidator();

           //act
           var result = FluentActions.Invoking(()=>validator.Validate(command)).Invoke();

           //assert
           Assert.True(result.Errors.Count > 0);

       }

       [Theory]
       [InlineData(2)]
       public void WhenValidInputActorIdAreGiven_Validator_ShouldNotBeReturnErrors(int id)
       {
           //arrenge
           DeleteMovieCommand command = new DeleteMovieCommand(null);
           command.MovieId  = id;
           DeleteMovieValidator validator = new DeleteMovieValidator();

           //act
           var result = FluentActions.Invoking(()=>validator.Validate(command)).Invoke();

           //assert
           Assert.True(result.Errors.Count <= 0);

       }
    }
}