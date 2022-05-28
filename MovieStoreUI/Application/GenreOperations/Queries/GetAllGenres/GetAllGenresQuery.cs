using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Application.GenreOperations.Queries.GetAllGenres
{
    public class GetAllGenresQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllGenresQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
 
        public List<GetAllGenresViewModel> Handle()
        {
            var genres = _dbContext.Genres.OrderBy(genres=>genres.Id).ToList();
            if(genres.Count < 1) throw new InvalidOperationException("Kayıtlı tür adları bulunamadı!!");
            List<GetAllGenresViewModel> viewModels = _mapper.Map<List<GetAllGenresViewModel>>(genres);

            return viewModels;
        }
    }

    public class GetAllGenresViewModel
    {
        public string Name { get; set; }
    }
}