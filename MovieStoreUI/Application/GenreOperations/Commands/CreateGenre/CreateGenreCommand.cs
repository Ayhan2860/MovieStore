using System;
using System.Linq;
using AutoMapper;
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

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(genre => genre.Name == Model.Name);
            if(genre is not null) throw new InvalidOperationException("Bu tür adı daha önce kayıt edilmiş");
            genre = _mapper.Map<Genre>(Model);
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();
        }
    }

    public class CreateGenreViewModel
    {
        public string Name { get; set; }
    }
}