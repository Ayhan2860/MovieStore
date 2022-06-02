using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.GenreOperations.Queries.GetGenreDetail;
using Xunit;

namespace MovieStore.UnitTests.Applications.GenreOperations.GenreQuery
{
    public class GetGenreDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(null)]
        public void WhenInvalidInputGenreIdAreGiven_Validator_ShouldBeErrors(int id)
        {
            // arrenge
            GetGenreDetailQuery query = new GetGenreDetailQuery(null, null);
            query.GenreId  =id;
            GetGenreDetailValidator validator = new GetGenreDetailValidator();

            // act
            var result = FluentActions.Invoking(()=>validator.Validate(query)).Invoke();

            // assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Theory]
        [InlineData(1)]
        public void WhenValidInputGenreIdAreGiven_Validator_ShouldNotBeReturnErrors(int id)
        {
            // arrenge
            GetGenreDetailQuery query = new GetGenreDetailQuery(null, null);
            query.GenreId  =id;
            GetGenreDetailValidator validator = new GetGenreDetailValidator();

            // act
            var result = FluentActions.Invoking(()=>validator.Validate(query)).Invoke();

            // assert
            result.Errors.Count.Should().BeLessThanOrEqualTo(0);

        }
        
    }
}