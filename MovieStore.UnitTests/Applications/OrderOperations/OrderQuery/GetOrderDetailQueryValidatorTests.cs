using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.OrderOperations.Queries.GetDetailOrder;
using Xunit;

namespace MovieStore.UnitTests.Applications.OrderOperations.OrderQuery
{
    public class GetOrderDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputOrderIdAreGiven_Validator_ShouldBeErrors()
        {
            //arrenge
            GetOrderDetailQuery query = new GetOrderDetailQuery(null, null);
            query.OrderId  = 0;
            GetOrderDetailValidator validator = new GetOrderDetailValidator();
            //act
            var result = FluentActions.Invoking(()=>validator.Validate(query)).Invoke();
            //assert
            Assert.True(result.Errors.Count > 0);
        }
        
        [Fact]
        public void WhenValidInputOrderIdAreGiven_Validator_ShouldNotBeErrors()
        {
            //arrenge
            GetOrderDetailQuery query = new GetOrderDetailQuery(null, null);
            query.OrderId  = 1;
            GetOrderDetailValidator validator = new GetOrderDetailValidator();
            //act
            var result = FluentActions.Invoking(()=>validator.Validate(query)).Invoke();
            //assert
            Assert.True(result.Errors.Count <= 0);
        }
    }
}