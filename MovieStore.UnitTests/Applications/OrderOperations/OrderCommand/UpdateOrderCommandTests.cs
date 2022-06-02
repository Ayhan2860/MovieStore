using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.OrderOperations.Commands.UpdateOrder;
using MovieStoreUI.DbOperations;
using Xunit;

namespace MovieStore.UnitTests.Applications.OrderOperations.OrderCommand
{
    public class UpdateOrderCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public UpdateOrderCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
     
        }


        [Fact]
        public void WhenAllReadyExistOrderIdGiven_ErrorResult_ShouldBeReturn()
        {
            //arrenge
            UpdateOrderCommand command = new UpdateOrderCommand(_context);
            command.OrderId = 0;

            // act
            var result = FluentActions.Invoking(()=>command.Handle()).Invoke();
            //assert
            result.Message.Should().Be("Silinecek Sipariş Bulunamadı");
            result.Success.Should().BeFalse();

        }


         [Fact]
        public void WhenAllReadyExistOrderIdGiven_Order_ShouldBeUpdate()
        {
            //arrenge
            UpdateOrderCommand command = new UpdateOrderCommand(_context);
            command.OrderId = 2;
            command.Model = new UpdateOrderViewModel {IsVisible = false};

            // act
            var result = FluentActions.Invoking(()=>command.Handle()).Invoke();
            //assert
            result.Message.Should().Be("Siparişiniz Silindi");
            result.Success.Should().BeTrue();

        }
    }
}