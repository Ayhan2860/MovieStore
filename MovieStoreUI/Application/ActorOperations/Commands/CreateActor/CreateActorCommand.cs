using System;
using System.Linq;
using AutoMapper;
using MovieStoreUI.Common.Results;
using MovieStoreUI.DbOperations;
using MovieStoreUI.Entities;

namespace MovieStoreUI.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommand
    {
        public CreateActorViewModel Model{ get; set;}
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateActorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IResult Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(actor =>actor.FirstName == Model.FirstName && actor.LastName == Model.LastName);
            if(actor is not null) return new ErrorResult("Bu Aktör Daha Önce Kayıt Edilmiş");
            actor = _mapper.Map<Actor>(Model);
            _dbContext.Actors.Add(actor);
              _dbContext.SaveChanges();
            return new SuccessResult("Aktör kaydedildi...");
        }
    }
    public class CreateActorViewModel
    {
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
    }
}