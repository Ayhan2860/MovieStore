using System;
using System.Linq;
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

        public void Handle()
      {
        var director = _dbContext.Directors.SingleOrDefault(director =>director.Id == DirectorId);
         if(director == null ) throw new InvalidOperationException("Yönetmen bulunamadı"); 
         director.FirstName = Model.FirstName != default ? Model.FirstName : director.FirstName;
         director.LastName = Model.LastName != default ? Model.LastName : director.LastName;
         _dbContext.SaveChanges();
      }
  }

    public class UpdateDirectorViewModel
    {
      public string FirstName { get; set; }
      
      public string LastName { get; set; }
      
      
    }
}