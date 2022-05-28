using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class MovieActorController:ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public MovieActorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        
    }
}