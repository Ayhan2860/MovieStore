using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.DirectorOperations.Queries.GetDirectorDetail;
using Xunit;

namespace MovieStore.UnitTests.Applications.DirectorOperations.DirectorQuery
{
    public class GetDirectorDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputDirectorIdAreGiven_Validator_ShouldBeErrors()
        {
             // arrenge
            GetDirectorDetailQuery query = new GetDirectorDetailQuery(null, null);
            query.DirectorId  = 0;
            GetDirectorDetailValidator validator = new GetDirectorDetailValidator();

            // act
            var result  = FluentActions.Invoking(()=> validator.Validate(query)).Invoke();

            // assert

             Assert.True(result.Errors.Count > 0);
        }

        [Fact]
        public void  WhenValidInputDirectorIdAreGiven_Validator_ShouldNotBeReturnErrors()
        {
             // arrenge
            GetDirectorDetailQuery query = new GetDirectorDetailQuery(null, null);
            query.DirectorId  = 2;
            GetDirectorDetailValidator validator = new GetDirectorDetailValidator();

            // act
            var result  = FluentActions.Invoking(()=> validator.Validate(query)).Invoke();

            // assert

             Assert.True(result.Errors.Count <= 0);
        }
    }
}