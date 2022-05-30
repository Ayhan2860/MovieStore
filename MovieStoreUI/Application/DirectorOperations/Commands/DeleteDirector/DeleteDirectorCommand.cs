using System;
using System.Linq;
using MovieStoreUI.Common.Results;
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

       public IResult Handle()
       {
           var director = _dbContext.Directors.SingleOrDefault(director =>director.Id == DirectorId);
           if(director is null) return new ErrorResult("Yönetmen Bulunamadı");
           _dbContext.Directors.Remove(director);
           _dbContext.SaveChanges();
           return new SuccessResult("Yönetmen Silindi");
       }
    }
}