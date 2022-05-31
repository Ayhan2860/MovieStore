using System;
using System.Linq;
using AutoMapper;
using MovieStoreUI.Common.Results;
using MovieStoreUI.DbOperations;
using MovieStoreUI.Entities;

namespace MovieStoreUI.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreViewModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateGenreCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IResult Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(genre => genre.Name == Model.Name);
            if(genre is not null) return new ErrorResult("Bu tür adı daha önce kayıt edilmiş");
            genre = _mapper.Map<Genre>(Model);
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();
            return new SuccessResult("Tür Adı Kaydedildi");
        }
    }

    public class CreateGenreViewModel
    {
        public string Name { get; set; }
    }
}