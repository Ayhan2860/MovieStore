using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Application.MovieActorOperations.Queries.GetByActorMovies
{
    public class GetByActorMoviesQuery
    {
       public int ActorId { get; set; }
       private readonly IMovieStoreDbContext _dbContext;
       private readonly IMapper _mapper;

        public GetByActorMoviesQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<ActorMoviesViewModel> Handle()
        {
            var movies = _dbContext.MovieActors.Include(ac => ac.Movie).Where(ma =>ma.ActorId == ActorId);
            if(movies is null) throw new InvalidOperationException("Oyuncuya ait film bulunamadı");
            var actorMovies = _mapper.Map<List<ActorMoviesViewModel>>(movies);
            return actorMovies;
        }

    }

    public class ActorMoviesViewModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }

    }
}