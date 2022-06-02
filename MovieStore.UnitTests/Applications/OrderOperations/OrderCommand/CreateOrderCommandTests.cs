using System.Linq;
using AutoMapper;
using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.OrderOperations.Commands.CreateOrder;
using MovieStoreUI.DbOperations;
using Xunit;

namespace MovieStore.UnitTests.Applications.OrderOperations.OrderCommand
{
    public class CreateOrderCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateOrderCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void WhenAllReadyExistOrderGiven_Order_ShouldBeCreated()
        {
            CreateOrderCommand command = new CreateOrderCommand(_context, _mapper);
            CreateOrderViewModel model = new CreateOrderViewModel
            {
                MovieId = 1,
                CustomerId = 2
            };
            command.Model = model;
            // act
            var result = FluentActions.Invoking(()=> command.Handle()).Invoke();
            //assert
            var order = _context.Orders.FirstOrDefault(x=>x.MovieId == model.MovieId && x.CustomerId == model.CustomerId);
            order.Should().NotBeNull();
            result.Message.Should().Be("Satın Alma İşlemi Gerçekleşti");
            result.Success.Should().BeTrue();

        }
    }
}