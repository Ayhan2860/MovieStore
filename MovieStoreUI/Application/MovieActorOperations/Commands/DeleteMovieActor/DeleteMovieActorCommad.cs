using System;
using System.Linq;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Application.MovieActorOperations.Commands.DeleteMovieActor
{
    public class DeleteMovieActor
    {
        public int MovieActorID { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public DeleteMovieActor(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var movieActor = _dbContext.MovieActors.SingleOrDefault(movieActor =>movieActor.ID == MovieActorID);
            if(movieActor is null) throw new InvalidOperationException("Film ve Aktör bilgileri bulunamadı");
            _dbContext.MovieActors.Remove(movieActor);
            _dbContext.SaveChanges();
        }
    }

    
}