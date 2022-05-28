using System;
using System.Linq;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        public int DirectorId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        public DeleteDirectorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

       public void Handle()
       {
           var director = _dbContext.Directors.SingleOrDefault(director =>director.Id == DirectorId);
           if(director is null) throw new InvalidOperationException("Yönetmen Bulunamadı");
           _dbContext.Directors.Remove(director);
           _dbContext.SaveChanges();
       }
    }
}