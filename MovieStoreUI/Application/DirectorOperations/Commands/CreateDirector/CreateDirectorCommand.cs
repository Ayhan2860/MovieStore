using System;
using System.Linq;
using AutoMapper;
using MovieStoreUI.Common.Results;
using MovieStoreUI.DbOperations;
using MovieStoreUI.Entities;

namespace MovieStoreUI.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommand
    {
        public CreateDirectorViewModel Model { get; set; }
        
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateDirectorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IResult Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault(director => director.FirstName == Model.FirstName && director.LastName == Model.LastName);
            if(director is not null) return new ErrorResult("Yönetmen daha önce kayıt edilmiş");
            director = _mapper.Map<Director>(Model);
            _dbContext.Directors.Add(director);
            _dbContext.SaveChanges();
            return new SuccessResult("Yönetmen Kaydı yapıldı");
        }
    }
    public class CreateDirectorViewModel
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        
    }   
}