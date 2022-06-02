using System;
using System.Linq;
using AutoMapper;
using MovieStoreUI.Common.Results;
using MovieStoreUI.DbOperations;
using MovieStoreUI.Entities;

namespace MovieStoreUI.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommand
    {
        public CreateOrderViewModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateOrderCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IResult Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == Model.MovieId);
             if(movie is null) return new ErrorResult("");
            var order = _mapper.Map<Order>(Model);
            order.OrderDate = DateTime.Now;
            order.OrderPrice = movie.Price; 
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return new SuccessResult("Satın Alma İşlemi Gerçekleşti");
        }

    }

     public class CreateOrderViewModel
    {
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
    }
}