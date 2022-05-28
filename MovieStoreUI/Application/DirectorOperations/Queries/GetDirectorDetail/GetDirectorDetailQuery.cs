using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public DirectorDetailViewModel Handle()
        {
            var director = _dbContext.Directors.Include(d=>d.Movies).SingleOrDefault(director =>director.Id == DirectorId);
            if(director is null) throw new InvalidOperationException("Yönetmen Bulunamadı!");
            DirectorDetailViewModel viewModel = _mapper.Map<DirectorDetailViewModel>(director);
            return viewModel;
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