using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.GenreOperations.Commands.UpdateGenre;
using Xunit;

namespace MovieStore.UnitTests.Applications.GenreOperations.GenreCommand
{
    public class UpdateGenreCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        
        [Theory]
        [InlineData(null, null)]
        public void WhenInvalidInputGenreIdAreGiven_Validator_ShouldBeErrors(int id, string name)
        {
             // arrenge
            UpdateGenreCommand command = new UpdateGenreCommand(null);
            command.GenreId = id;
            command.Model = new UpdateGenreViewModel{ Name = name};
            UpdateGenreValidator validator = new UpdateGenreValidator();

            //act
            var result = FluentActions.Invoking(()=> validator.Validate(command)).Invoke();

            //assert
            Assert.True(result.Errors.Count > 0);
        }

         [Theory]
        [InlineData(1, "Polisiye")]
        public void WhenValidInputGenreIdAreGiven_Validator_ShouldNotBeReturnErrors(int id, string name)
        {
             // arrenge
            UpdateGenreCommand command = new UpdateGenreCommand(null);
            command.GenreId = id;
            command.Model = new UpdateGenreViewModel{ Name = name};
            UpdateGenreValidator validator = new UpdateGenreValidator();

            //act
            var result = FluentActions.Invoking(()=> validator.Validate(command)).Invoke();

            //assert
            Assert.True(result.Errors.Count <= 0);
        }
    }
}