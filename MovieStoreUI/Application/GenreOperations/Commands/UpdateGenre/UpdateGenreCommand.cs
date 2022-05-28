using System;
using System.Linq;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int GenreId { get; set; }
        public UpdateGenreViewModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public UpdateGenreCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(g => g.Id == GenreId);
             if(genre == null)  throw new InvalidOperationException("Tür sistemde kayıtlı değil");
             genre.Name = Model.Name != default ? Model.Name :genre.Name;
             _dbContext.SaveChanges();
        }

    }

    public class UpdateGenreViewModel
    {
        public string Name { get; set; }
    }
}