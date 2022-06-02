using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreUI.Common.Results;
using MovieStoreUI.DbOperations;
using MovieStoreUI.Entities;

namespace MovieStoreUI.Application.MovieOperations.Queries.GetMovies
{
    public class GetMoviesQueries
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetMoviesQueries(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IDataResult<List<GetMoviesViewModel>> Handle()
        {
            var movies = _dbContext.Movies.Include(movies=>movies.MovieActors).ThenInclude(movies=>movies.Actor).Include(movie => movie.Director).Include(movie=>movie.Genre).ToList();
            if(movies.Count < 1) return new ErrorDataResult<List<GetMoviesViewModel>>("Film verisi bulunamadı!");
            List<GetMoviesViewModel> viewModels = _mapper.Map<List<GetMoviesViewModel>>(movies);
            return new SuccessDataResult<List<GetMoviesViewModel>>(viewModels);
        }
    }

    public class GetMoviesViewModel
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; } 

        public List<Actors>  MovieActors { get; set; }
        public  struct Actors
        {
            public string  FullName { get; set; }
        }

    }
}