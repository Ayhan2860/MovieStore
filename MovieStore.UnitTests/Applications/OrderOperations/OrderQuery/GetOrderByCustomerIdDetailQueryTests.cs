using System.Linq;
using AutoMapper;
using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.OrderOperations.Queries.GetByCustomerIdOrderDetail;
using MovieStoreUI.DbOperations;
using Xunit;

namespace MovieStore.UnitTests.Applications.OrderOperations.OrderQuery
{
    public class GetOrderByCustomerIdDetailQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetOrderByCustomerIdDetailQueryTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }
        [Fact]
        public void WhenAllReadyExistCustomerIdInputGiven_ErrorResult_ShouldBeReturn()
        {
             //arrenge
            GetOrderByCustomerIdDetailQuery query = new GetOrderByCustomerIdDetailQuery(_context, _mapper);
            query.CustomerId = 0;
            //act
            var result = FluentActions.Invoking(()=>query.Handle()).Invoke();
            //assert
            result.Data.Should().BeNull();
            result.Message.Should().Be("Sipariş Bulunamadı");
            result.Success.Should().BeFalse();

        }

        [Fact]
        public void WhenAllReadyExistCustomerIdInputGiven_Order_ShouldBeOrderDetail()
        {
             //arrenge
            GetOrderByCustomerIdDetailQuery query = new GetOrderByCustomerIdDetailQuery(_context, _mapper);
            query.CustomerId = 1;
            //act
            var result = FluentActions.Invoking(()=>query.Handle()).Invoke();
            //assert
            var order = _context.Orders.Where(x => x.CustomerId == 1).ToList();
            result.Data.Count.Should().Be(order.Count);
            result.Data.Should().NotBeNull();
            result.Success.Should().BeTrue();

        }
    }
}