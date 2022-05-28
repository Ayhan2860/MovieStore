using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.ActorOperations.Queries.GetActorDetail;
using Xunit;

namespace MovieStore.UnitTests.Applications.ActorOperations.ActorQuery
{
    public class GetActorDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(null)]
        public void WhenInvalidInputActorIdAreGiven_Validator_ShouldBeReturnErrors(int id)
        {
            //arrenge
            GetActorDetailQuery query = new GetActorDetailQuery(null, null);
            query.ActorId = id;

            // act
            GetActorDetailValidator validator = new GetActorDetailValidator();
            var result  = validator.Validate(query);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputAuthorAreGiven_Validator_ShouldNotBeReturnErrors()
        {
              //arrenge
            GetActorDetailQuery query = new GetActorDetailQuery(null, null);
            query.ActorId = 1;

            // act
            GetActorDetailValidator validator = new GetActorDetailValidator();
            var result  = validator.Validate(query);

            //assert
            Assert.True(result.Errors.Count <= 0 );
        }
    }
}