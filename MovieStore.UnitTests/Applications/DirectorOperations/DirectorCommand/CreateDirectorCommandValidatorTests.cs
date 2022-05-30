using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.DirectorOperations.Commands.CreateDirector;
using Xunit;

namespace MovieStore.UnitTests.Applications.DirectorOperations.DirectorCommand
{
    public  class CreateDirectorCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("", "")]
        public void WhenAllReadyExistDirectorInputGiven_Validator_ShouldBeErrors(string firstName, string lastName)
        {
            //arrenge
            CreateDirectorCommand command = new CreateDirectorCommand(null, null);
            command.Model = new CreateDirectorViewModel{
                FirstName  = firstName,
                LastName = lastName
            };
            CreateDirectorValidator validator = new CreateDirectorValidator();

            // act 
            var result = FluentActions.Invoking(()=>validator.Validate(command)).Invoke();

            // assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Theory]
        [InlineData("Mevlüt", "Karaman")]
        public void WhenAllReadyExistDirectorInputGiven_Validator_ShouldNotBeErrors(string firstName, string lastName)
        {
            //arrenge
            CreateDirectorCommand command = new CreateDirectorCommand(null, null);
            command.Model = new CreateDirectorViewModel{
                FirstName  = firstName,
                LastName = lastName
            };
            CreateDirectorValidator validator = new CreateDirectorValidator();

            // act 
            var result = FluentActions.Invoking(()=>validator.Validate(command)).Invoke();

            // assert
            result.Errors.Count.Should().BeLessThanOrEqualTo(0);

        }
    }
}