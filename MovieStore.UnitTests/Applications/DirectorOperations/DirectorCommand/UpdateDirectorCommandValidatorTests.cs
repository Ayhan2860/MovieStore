using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.DirectorOperations.Commands.UpdateDirector;
using Xunit;

namespace MovieStore.UnitTests.Applications.DirectorOperations.DirectorCommand
{
    public class UpdateDirectorCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0, "", "")]
        [InlineData(null, null, null)]
        public void WhenAllReadyExistDirectorIdInputGiven_Validator_ShouldBeErrors(int id, string firstName, string lastName)
        {
            // arrenge
            UpdateDirectorCommand command = new UpdateDirectorCommand(null);
            command.DirectorId = id;
            command.Model = new UpdateDirectorViewModel
            {
                FirstName =  firstName,
                LastName = lastName
            };
            UpdateDirectorValidator validator = new UpdateDirectorValidator();

            //act
            var result = FluentActions.Invoking(()=> validator.Validate(command)).Invoke();

            //
            result.Errors.Count.Should().BeGreaterThan(0);
            
        }

        [Theory]
        [InlineData(1, "Engin", "Demiroğ")]
        public void WhenAllReadyExistDirectorIdInputGiven_Validator_ShouldNotBeErrors(int id, string firstName, string lastName)
        {
            // arrenge
            UpdateDirectorCommand command = new UpdateDirectorCommand(null);
            command.DirectorId = id;
            command.Model = new UpdateDirectorViewModel
            {
                FirstName = firstName,
                LastName = lastName
            };
            UpdateDirectorValidator validator = new UpdateDirectorValidator();

            //act
            var result = FluentActions.Invoking(()=> validator.Validate(command)).Invoke();

            //
            result.Errors.Count.Should().BeLessThanOrEqualTo(0);
            
        }
    }
}