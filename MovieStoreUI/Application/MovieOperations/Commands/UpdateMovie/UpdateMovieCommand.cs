using System;
using System.Linq;
using MovieStoreUI.Common.Results;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommand
    {
         public int MovieId { get; set; }
         public UpdateMovieViewModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public UpdateMovieCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IResult Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(movie=>movie.Id == MovieId);
            if(movie is null) return new ErrorResult("Güncellenecek film bulunamadı");
              movie.Title = Model.Title != default ? Model.Title : movie.Title;
              movie.DirectorId = Model.DirectorId != default ? Model.DirectorId : movie.DirectorId;
              movie.GenreId = Model.GenreId != default ? Model.GenreId : movie.GenreId;
              movie.Price = Model.Price != default ? Model.Price : movie.Price;
              movie.ReleaseDate = Model.ReleaseDate != default ? Model.ReleaseDate : movie.ReleaseDate;
              _dbContext.SaveChanges();
              return new SuccessResult("Film Güncellendi");
        }
    }

    public class UpdateMovieViewModel
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }        
       
    }
}