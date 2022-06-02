using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.OrderOperations.Queries.GetByCustomerIdOrderDetail;
using Xunit;

namespace MovieStore.UnitTests.Applications.OrderOperations.OrderQuery
{
    public class GetOrderByCustomerIdDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputCustomerIdAreGiven_Validator_ShouldBeErrors()
        {
            //arrenge
            GetOrderByCustomerIdDetailQuery query = new GetOrderByCustomerIdDetailQuery(null, null);
            query.CustomerId = 0;
            GetOrderByCustomerIdDetailValidator validator = new GetOrderByCustomerIdDetailValidator(); 
            //act
            var result = FluentActions.Invoking(()=>validator.Validate(query)).Invoke();

            //assert
            Assert.True(result.Errors.Count > 0);

        }

        [Fact]
        public void WhenValidInputCustomerIdAreGiven_Validator_ShouldNotBeErrors()
        {
            //arrenge
            GetOrderByCustomerIdDetailQuery query = new GetOrderByCustomerIdDetailQuery(null, null);
            query.CustomerId = 1;
            GetOrderByCustomerIdDetailValidator validator = new GetOrderByCustomerIdDetailValidator(); 
            //act
            var result = FluentActions.Invoking(()=>validator.Validate(query)).Invoke();

            //assert
            Assert.True(result.Errors.Count <= 0);

        }
    }
}