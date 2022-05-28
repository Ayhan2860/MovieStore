using System;
using System.Linq;
using AutoMapper;
using MovieStoreUI.DbOperations;
using MovieStoreUI.Entities;

namespace MovieStoreUI.Application.MovieActorOperations.Commands.CreateMovieActor
{
    public class CreateMovieActorCommand
    {
        public CreateMovieActorViewModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateMovieActorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie = _dbContext.Movies.Any(movie => movie.Id == Model.MovieId);
            var actor = _dbContext.Actors.Any(actor => actor.Id == Model.ActorId);
            var movieActor = _dbContext.MovieActors.SingleOrDefault(movieActor => movieActor.MovieId == Model.MovieId && movieActor.ActorId == Model.ActorId);
            if(!movie) throw new InvalidOperationException("Film kaydı bulunamadı");
            if(!actor) throw new InvalidOperationException("Aktör kaydı bulunamadı");
            if(movieActor is not null) throw new InvalidOperationException("Böyle bir kayıt daha önce oluşturulmuş");
            movieActor = _mapper.Map<MovieActor>(Model);
            _dbContext.MovieActors.Add(movieActor);
            _dbContext.SaveChanges();
        }
    }
    public class CreateMovieActorViewModel
    {
        public int ActorId { get; set; }
        public int MovieId { get; set; }
    }
}