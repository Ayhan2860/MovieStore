using System;
using System.Linq;
using AutoMapper;
using MovieStoreUI.Common.Results;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public GetGenreDetailViewModel MyProperty { get; set; }
        public int GenreId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetGenreDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IDataResult<GetGenreDetailViewModel> Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(genre => genre.Id == GenreId);
            if(genre is null) return new ErrorDataResult<GetGenreDetailViewModel>("Bu isimde böyle bir tür bulunamadı");
            GetGenreDetailViewModel viewModel = _mapper.Map<GetGenreDetailViewModel>(genre);
            return new SuccessDataResult<GetGenreDetailViewModel>(viewModel, "Tür Adı Bulundu");
        }

    }
    public class GetGenreDetailViewModel
    {
        public string Name { get; set; }
    }
}