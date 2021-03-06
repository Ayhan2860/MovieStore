using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreUI.Common.Results;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Application.DirectorOperations.Queries.GetDirectors
{
    public class GetDirectorsQueries
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetDirectorsQueries(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
         
         public IDataResult<List<GetDirectorsViewModel>> Handle()
         {
             var directors = _dbContext.Directors.Include(d=>d.Movies).OrderBy(movie=>movie.Id).ToList();
             if(directors.Count < 1) return new ErrorDataResult<List<GetDirectorsViewModel>>("Yönetmen Bulunamadı");
             List<GetDirectorsViewModel> viewModel = _mapper.Map<List<GetDirectorsViewModel>>(directors);
             return new SuccessDataResult<List<GetDirectorsViewModel>>(viewModel, "Tüm Yönetmenler Listelendi...");

         }

    }
     public class GetDirectorsViewModel
     {
         public string FullName { get; set; }
         public List<MovieList> Movies { get; set; }
         
         
         public struct MovieList
         {
             public string Title { get; set; }
         }
         
     }
}