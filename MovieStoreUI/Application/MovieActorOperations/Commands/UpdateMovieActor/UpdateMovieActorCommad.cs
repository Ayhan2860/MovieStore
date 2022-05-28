using System;
using System.Linq;
using AutoMapper;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Application.MovieActorOperations.Commands.UpdateMovieActor
{
    public class UpdateMovieActorCommand
    {
        public int MovieActorID { get; set; }
        public UpdateMovieActorViewModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public UpdateMovieActorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

       public void Handle()
       {
           var movieActor = _dbContext.MovieActors.SingleOrDefault(movieActor => movieActor.ID == MovieActorID);
            if(movieActor is null) throw new InvalidOperationException("Böyle bir kayıt bulunamadı");
            movieActor.MovieId = Model.MovieId != default ? Model.MovieId : movieActor.MovieId;
            movieActor.ActorId = Model.ActorId != default ? Model.ActorId : movieActor.ActorId;
            _dbContext.SaveChanges();
       } 
    }

    public class UpdateMovieActorViewModel
    {
        public int ActorId { get; set; }
        public int MovieId { get; set; }
    }
}