using System;
using System.Linq;
using MovieStoreUI.Common.Results;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommand
    {
        public int MovieId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public DeleteMovieCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IResult Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(movie =>movie.Id == MovieId);
            if(movie is null) return new ErrorResult("Silinecek film bulunamadı");
            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();
            return new SuccessResult("Film Kaydı Silindi");
        }
    }
}