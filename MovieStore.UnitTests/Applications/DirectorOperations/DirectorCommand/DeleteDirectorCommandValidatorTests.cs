using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.DirectorOperations.Commands.DeleteDirector;
using Xunit;

namespace MovieStore.UnitTests.Applications.DirectorOperations.DirectorCommand
{
    public class DeleteDirectorCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenAllReadyExistDirectorIdInputGiven_Validator_ShouldBeErrors()
        {
            //arrenge
            DeleteDirectorCommand command = new DeleteDirectorCommand(null);
            command.DirectorId  = 0;
            DeleteDirectorValidator validator = new DeleteDirectorValidator();
            //act
            var result = FluentActions.Invoking(()=> validator.Validate(command)).Invoke();

            //assert
            Assert.True(result.Errors.Count > 0);
        }

        [Fact]
        public void WhenAllReadyExistDirectorIdInputGiven_Validator_ShouldNotBeErrors()
        {
            //arrenge
            DeleteDirectorCommand command = new DeleteDirectorCommand(null);
            command.DirectorId  = 1;
            DeleteDirectorValidator validator = new DeleteDirectorValidator();
            //act
            var result = FluentActions.Invoking(()=> validator.Validate(command)).Invoke();

            //assert
            Assert.True(result.Errors.Count <= 0);
        }
    }
}