using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.GenreOperations.Commands.CreateGenre;
using Xunit;

namespace MovieStore.UnitTests.Applications.GenreOperations.GenreCommand
{
    public class CreateGenreCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("")]
        public void WhenAllReadyExistInputGiven_Validator_ShouldBeErrors(string name)
        {
             // arrenge
            CreateGenreCommand command = new CreateGenreCommand(null, null);
            command.Model = new CreateGenreViewModel
            {
                Name = name
            };
            CreateGenreValidator validator = new CreateGenreValidator();
            //act
            var result =  FluentActions.Invoking(()=> validator.Validate(command)).Invoke();
            //assert
            Assert.True(result.Errors.Count > 0);
        }

        [Theory]
        [InlineData("Komedi")]
        public void WhenAllReadyExistInputGiven_Validator_ShouldNotBeErrors(string name)
        {
             // arrenge
            CreateGenreCommand command = new CreateGenreCommand(null, null);
            command.Model = new CreateGenreViewModel
            {
                Name = name
            };
            CreateGenreValidator validator = new CreateGenreValidator();
            //act
            var result =  FluentActions.Invoking(()=> validator.Validate(command)).Invoke();
            //assert
            Assert.True(result.Errors.Count <= 0);
        }
    }
}