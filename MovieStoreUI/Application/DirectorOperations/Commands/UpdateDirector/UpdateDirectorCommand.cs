using System;
using System.Linq;
using MovieStoreUI.Common.Results;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Application.DirectorOperations.Commands.UpdateDirector
{
  public class UpdateDirectorCommand
  {
      public int DirectorId { get; set; }
      
      public UpdateDirectorViewModel Model { get; set; }
      
      private readonly IMovieStoreDbContext _dbContext;

        public UpdateDirectorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IResult Handle()
      {
        var director = _dbContext.Directors.SingleOrDefault(director =>director.Id == DirectorId);
         if(director == null ) return new ErrorResult("Yönetmen bulunamadı"); 
         director.FirstName = Model.FirstName != default ? Model.FirstName : director.FirstName;
         director.LastName = Model.LastName != default ? Model.LastName : director.LastName;
         _dbContext.SaveChanges();
         return new SuccessResult("Yönetmen Güncellendi...");
      }
  }

    public class UpdateDirectorViewModel
    {
      public string FirstName { get; set; }
      
      public string LastName { get; set; }
      
      
    }
}