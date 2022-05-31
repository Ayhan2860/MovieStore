using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MovieStoreUI.Common.Results;
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
 
        public IDataResult<List<GetAllGenresViewModel>> Handle()
        {
            var genres = _dbContext.Genres.OrderBy(genres=>genres.Id).ToList();
            if(genres.Count < 1) return new ErrorDataResult<List<GetAllGenresViewModel>>("Kayıtlı tür adları bulunamadı!!");
            List<GetAllGenresViewModel> viewModels = _mapper.Map<List<GetAllGenresViewModel>>(genres);

            return new SuccessDataResult<List<GetAllGenresViewModel>>(viewModels);
        }
    }

    public class GetAllGenresViewModel
    {
        public string Name { get; set; }
    }
}