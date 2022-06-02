using System;
using System.Linq;
using MovieStoreUI.Common.Results;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Application.OrderOperations.Commands.UpdateOrder
{
    public class UpdateOrderCommand
    {
        public UpdateOrderViewModel Model { get; set; }
        public int OrderId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public UpdateOrderCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IResult Handle()
        {
            var order = _dbContext.Orders.SingleOrDefault(o=> o.Id == OrderId);
            if(order is null) return new ErrorResult("Silinecek Sipariş Bulunamadı");
            order.IsVisible  = Model.IsVisible != default ? Model.IsVisible : order.IsVisible;
            _dbContext.SaveChanges();
            return new SuccessResult("Siparişiniz Silindi");

        }

    }

    public class UpdateOrderViewModel
    {
        public bool IsVisible { get; set; }
    }
}