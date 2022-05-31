using System;
using System.Linq;
using MovieStoreUI.Common.Results;
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

        public IResult Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(g => g.Id == GenreId);
             if(genre == null)  return new ErrorResult("Tür sistemde kayıtlı değil");
             genre.Name = Model.Name != default ? Model.Name :genre.Name;
             _dbContext.SaveChanges();
             return new SuccessResult("Tür Adı Güncellendi");
        }

    }

    public class UpdateGenreViewModel
    {
        public string Name { get; set; }
    }
}