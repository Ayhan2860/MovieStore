using AutoMapper;
using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.OrderOperations.Queries.GetDetailOrder;
using MovieStoreUI.DbOperations;
using Xunit;

namespace MovieStore.UnitTests.Applications.OrderOperations.OrderQuery
{
    public class GetOrderDetailQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetOrderDetailQueryTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void WhenAllReadyExistOrderIdInputGiven_ErrorResult_ShouldBeReturn()
        {
            //arrenge
            GetOrderDetailQuery query = new GetOrderDetailQuery(_context, _mapper);
            query.OrderId  = 0;
            //act
            var result =  FluentActions.Invoking(()=>query.Handle()).Invoke();
            //assert
            result.Data.Should().BeNull();
            result.Message.Should().Be("Sipariş Bulunamadı...");
            result.Success.Should().BeFalse();

        }

        [Fact]
        public void WhenAllReadyExistOrderIdInputGiven_Order_ShouldBeOrderDetail()
        {
             //arrenge
            GetOrderDetailQuery query = new GetOrderDetailQuery(_context, _mapper);
            query.OrderId  = 1;
            //act
            var result =  FluentActions.Invoking(()=>query.Handle()).Invoke();
            //assert
            result.Data.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }
    }
}
