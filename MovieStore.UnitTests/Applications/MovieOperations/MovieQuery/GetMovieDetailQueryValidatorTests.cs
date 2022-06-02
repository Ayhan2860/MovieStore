using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.MovieOperations.Queries.GetMovieDetail;
using Xunit;

namespace MovieStore.UnitTests.Applications.MovieOperations.MovieQuery
{
    public class GetMovieDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputMovieIdAreGiven_Validator_ShouldBeErrors()
        {
            //arrenge
            GetMovieDetailQuery query = new GetMovieDetailQuery(null, null);
            query.MovieId = 0;
            GetMovieDetailValidator validator = new GetMovieDetailValidator();
            // act
            var result = FluentActions.Invoking(()=> validator.Validate(query)).Invoke();
            //assert
            Assert.True(result.Errors.Count > 0);
        }

        [Fact]
        public void WhenValidInputActorIdAreGiven_Validator_ShouldNotBeReturnErrors()
        {
            //arrenge
            GetMovieDetailQuery query = new GetMovieDetailQuery(null, null);
            query.MovieId = 3;
            GetMovieDetailValidator validator = new GetMovieDetailValidator();
            // act
            var result = FluentActions.Invoking(()=> validator.Validate(query)).Invoke();
            //assert
            Assert.True(result.Errors.Count <= 0);
        }
    }
}