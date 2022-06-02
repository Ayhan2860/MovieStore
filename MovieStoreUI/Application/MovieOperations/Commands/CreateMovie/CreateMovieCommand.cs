using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreUI.Common.Results;
using MovieStoreUI.DbOperations;
using MovieStoreUI.Entities;

namespace MovieStoreUI.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommand
    {
        public CreateMovieViewModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateMovieCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IResult Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(movie => movie.Title == Model.Title);
            if(movie is not null) return new ErrorResult("Bu film daha önce kayıt edilmiş");
             movie = _mapper.Map<Movie>(Model);
             _dbContext.Movies.Add(movie);
             _dbContext.SaveChanges();
             return new SuccessResult("Film Kaydedildi");
        }
    }

    public class CreateMovieViewModel
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }        
       
    }
}