using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreUI.Common.Results;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Application.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQuery
    {
        public int MovieId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetMovieDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IDataResult<GetMovieViewModel> Handle()
        {
            var movie = _dbContext.Movies.Include(movie=>movie.MovieActors).ThenInclude(movie=>movie.Actor).Include(movie=>movie.Director).Include(movie=>movie.Genre).SingleOrDefault(movie =>movie.Id == MovieId);
            if(movie is null) return new ErrorDataResult<GetMovieViewModel>("Film Bulunamadı!");
            GetMovieViewModel viewModel = _mapper.Map<GetMovieViewModel>(movie);
            return new SuccessDataResult<GetMovieViewModel>(viewModel);
        }
        
    }
    public class GetMovieViewModel
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