using System;
using System.Linq;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Application.OrderOperations.Commands.DeleteOrder
{
    public class DeleteOrderCommand
    {
        public int OrderId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public DeleteOrderCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var order = _dbContext.Orders.SingleOrDefault(o => o.Id == OrderId);
            if (order is null) throw new InvalidOperationException("Sipariş bulunamadı");
             order.IsVisible = false;
            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
        }
    }
}