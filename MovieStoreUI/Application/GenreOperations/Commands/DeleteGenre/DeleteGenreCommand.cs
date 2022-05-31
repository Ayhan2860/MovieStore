using System;
using System.Linq;
using MovieStoreUI.Common.Results;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Application.GenreOperations.Commands.DeletGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public DeleteGenreCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IResult Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(genre=>genre.Id == GenreId);
            if(genre is null) return new ErrorResult("Böyle bir tür adı bulunamadı");
            _dbContext.Genres.Remove(genre);
            _dbContext.SaveChanges();
            return new SuccessResult("Tür Adı Silindi");
        }
    }
}