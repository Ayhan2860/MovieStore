using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreUI.Common.Results;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Application.ActorOperations.Queries.GetActors
{
    public class GetActorQueries
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetActorQueries(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IDataResult<List<ActorsViewModel>> Handle()
        {
            var actors = _dbContext.Actors.Include(a => a.MovieActors).ThenInclude(x =>  x.Movie).OrderBy(a => a.Id).ToList();
            if(actors.Count <1)  return new ErrorDataResult<List<ActorsViewModel>>("Actor Bulunamdı");
            List<ActorsViewModel>  viewModels = _mapper.Map<List<ActorsViewModel>>(actors);
            return new SuccessDataResult<List<ActorsViewModel>>(viewModels, "Tüm aktörler listelendi");
        }
        
    }

    public class ActorsViewModel
    {
        public string FullName { get; set; }
        public List<MovieActorViewModel> Movies { get; set; }
         
         
          public struct MovieActorViewModel
         {
             public int Id { get; set; }
             
             public string Title { get; set; }
         }

    }

}