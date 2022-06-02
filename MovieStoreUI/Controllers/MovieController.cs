using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStoreUI.Application.MovieOperations.Commands.CreateMovie;
using MovieStoreUI.Application.MovieOperations.Commands.DeleteMovie;
using MovieStoreUI.Application.MovieOperations.Commands.UpdateMovie;
using MovieStoreUI.Application.MovieOperations.Queries.GetMovieDetail;
using MovieStoreUI.Application.MovieOperations.Queries.GetMovies;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Controllers
{
   
    [Route("[controller]s")]
    [ApiController]
    public class MovieController:ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public MovieController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            GetMoviesQueries query = new GetMoviesQueries(_context, _mapper);
            var result = query.Handle();
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetByIdMovie(int id)
        {
            GetMovieDetailQuery query = new GetMovieDetailQuery(_context, _mapper);
            query.MovieId = id;
            var result = query.Handle();
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost]
        public IActionResult CreateMovie([FromBody] CreateMovieViewModel movieModel)
        {
            CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
            command.Model = movieModel;
            var result = command.Handle();
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie([FromBody] UpdateMovieViewModel movieModel, int id)
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_context);
            command.MovieId = id;
            command.Model = movieModel;
            var result = command.Handle();
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

         [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            DeleteMovieCommand command = new DeleteMovieCommand(_context);
            command.MovieId = id;
            var result = command.Handle();
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}