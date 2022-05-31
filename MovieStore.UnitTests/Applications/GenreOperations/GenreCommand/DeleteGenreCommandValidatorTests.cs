using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.GenreOperations.Commands.DeletGenre;
using Xunit;

namespace MovieStore.UnitTests.Applications.GenreOperations.GenreCommand
{
    public class DeleteGenreCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(null)]
        public void WhenAllReadyExistGenreIdInputGiven_Validator_ShouldBeErrors(int id)
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
        public void WhenAllReadyExistGenreIdInputGiven_Validator_ShouldNotBeErrors(int id)
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