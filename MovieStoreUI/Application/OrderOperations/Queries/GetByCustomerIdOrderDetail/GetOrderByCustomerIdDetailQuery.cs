using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreUI.Common.Results;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Application.OrderOperations.Queries.GetByCustomerIdOrderDetail
{
    public class GetOrderByCustomerIdDetailQuery
    {
        public int CustomerId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private IMapper _mapper;
        public GetOrderByCustomerIdDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IDataResult<List<GetByCustomerIdOrderDetailViewModel>> Handle()
        {
            var orders = _dbContext.Orders.Include(order => order.Movie).Where(x => x.CustomerId == CustomerId).ToList();
            if(orders.Count < 1)
                return new ErrorDataResult<List<GetByCustomerIdOrderDetailViewModel>>("Sipariş Bulunamadı");
            List<GetByCustomerIdOrderDetailViewModel> viewModel = _mapper.Map<List<GetByCustomerIdOrderDetailViewModel>>(orders);
            return new SuccessDataResult<List<GetByCustomerIdOrderDetailViewModel>>(viewModel);
        }
    }
   public class GetByCustomerIdOrderDetailViewModel
   {
       public int Id { get; set; }
       public string Movie { get; set; }
       public DateTime OrderDate { get; set; }
       public double OrderPrice { get; set; }
       public bool IsVisible { get; set; }
   }
}