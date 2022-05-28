using System;
using System.Linq;
using AutoMapper;
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
        public GetGenreDetailViewModel Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(genre => genre.Id == GenreId);
            if(genre is null) throw new InvalidOperationException("Bu isimde böyle bir tür bulunamadı");
            GetGenreDetailViewModel viewModel = _mapper.Map<GetGenreDetailViewModel>(genre);
            return viewModel;
        }

    }
    public class GetGenreDetailViewModel
    {
        public string Name { get; set; }
    }
}