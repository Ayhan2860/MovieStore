using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.GenreOperations.Commands.DeletGenre;
using Xunit;

namespace MovieStore.UnitTests.Applications.GenreOperations.GenreCommand
{
    public class DeleteGenreCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        // WhenInvalidInputGenreIdAreGiven_Validator_ShouldBeErrors
// WhenValidInputGenreIdAreGiven_Validator_ShouldNotBeReturnErrors
        [Theory]
        [InlineData(null)]
        public void WhenInvalidInputGenreIdAreGiven_Validator_ShouldBeErrors(int id)
        {
            // arrenge
            DeleteGenreCommand command = new DeleteGenreCommand(null);
            command.GenreId = id;

            DeleteGenreValidator validator = new DeleteGenreValidator();

            // act
            var result = FluentActions.Invoking(()=> validator.Validate(command)).Invoke();

            // assert
            Assert.True(result.Errors.Count > 0);

        }

        [Theory]
        [InlineData(4)]
        public void  WhenValidInputGenreIdAreGiven_Validator_ShouldNotBeReturnErrors(int id)
        {
            // arrenge
            DeleteGenreCommand command = new DeleteGenreCommand(null);
            command.GenreId = id;

            DeleteGenreValidator validator = new DeleteGenreValidator();

            // act
            var result = FluentActions.Invoking(()=> validator.Validate(command)).Invoke();

            // assert
            Assert.True(result.Errors.Count <= 0);

        }
    }
}