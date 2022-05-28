using System;
using System.Linq;
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

        public void Handle()
        {
            var order = _dbContext.Orders.SingleOrDefault(o=> o.Id == OrderId);
            if(order is null) throw new InvalidOperationException("Güncellenecek Sipariş Bulunamadı");
            order.CustomerId = Model.CustomerId != default ? Model.CustomerId : order.CustomerId;
            order.MovieId = Model.MovieId != default ? Model.MovieId : order.MovieId;
            order.OrderPrice  = Model.OrderPrice != default ? Model.OrderPrice : order.OrderPrice;
            _dbContext.SaveChanges();

        }

    }

    public class UpdateOrderViewModel
    {
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public double OrderPrice { get; set; }
    }
}