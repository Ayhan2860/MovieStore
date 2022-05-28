using System;
using System.Linq;
using MovieStoreUI.Common.Results;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommand
    {
       public int ActorId { get; set; }
       private readonly IMovieStoreDbContext _dbContext;

        public DeleteActorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IResult Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(actor=>actor.Id == ActorId);
            if(actor is null) return new ErrorResult("Actor Bulunamadı");
            _dbContext.Actors.Remove(actor);
            _dbContext.SaveChanges();
            return new SuccessResult("Aktör Başarıyla Silindi..");
        }

    }
}