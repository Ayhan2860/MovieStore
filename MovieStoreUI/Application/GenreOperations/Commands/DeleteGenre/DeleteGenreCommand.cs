using System;
using System.Linq;
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

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(genre=>genre.Id == GenreId);
            if(genre is null) throw new InvalidOperationException("Böyle bir tür adı bulunamadı");
            _dbContext.Genres.Remove(genre);
            _dbContext.SaveChanges();
        }
    }
}