using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreUI.Common.Results;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Application.CustomerOperations.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQuery
    {
        public int CustomerId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetCustomerDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IDataResult<CustomerDetailViewModel> Handle()
        {
            var customer = _dbContext.Customers.Include(c =>c.CustomerFavoritGenres)
            .ThenInclude(fg => fg.Genre)
            .Include(c =>c.OrderMovies)
            .ThenInclude(og =>og.Movie).SingleOrDefault(c =>c.Id == CustomerId);

            if(customer is null) throw new InvalidOperationException("Müşteri Bulunamadı");
               CustomerDetailViewModel viewModel = _mapper.Map<CustomerDetailViewModel>(customer);

            return new SuccessDataResult<CustomerDetailViewModel>(viewModel);
        }
    }

    public class CustomerDetailViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<OrderVM> OrderVMs { get; set; }
        public List<CustomerFavoritGenreVM> FavoritGenres { get; set; }
        public struct OrderVM
        {
            public int Id { get; set; }
            public MovieDetailVM Movie { get; set; }
            public double OrderPrice { get; set; }
            public DateTime OrderDate { get; set; }

            
        }
        public struct MovieDetailVM
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public double Price { get; set; }
        }
        public struct CustomerFavoritGenreVM
        {
           public int Id { get; set; }
           public string Name { get; set; }   
        }
    
    }
}