using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreUI.Common.Results;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Application.DirectorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQuery
    {
        public int DirectorId { get; set; }
        
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetDirectorDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IDataResult<DirectorDetailViewModel> Handle()
        {
            var director = _dbContext.Directors.Include(d=>d.Movies).SingleOrDefault(director =>director.Id == DirectorId);
            if(director is null) return new ErrorDataResult<DirectorDetailViewModel>("Yönetmen Bulunamadı!");
            DirectorDetailViewModel viewModel = _mapper.Map<DirectorDetailViewModel>(director);
            return new SuccessDataResult<DirectorDetailViewModel>(viewModel, "Yönetmen Bulundu");
        }
    }
    public class DirectorDetailViewModel
    {
        public string FullName { get; set; }
         public List<MovieList> Movies { get; set; } 
         public struct MovieList
         {
             public string Title { get; set; }
         }
        
    }
}