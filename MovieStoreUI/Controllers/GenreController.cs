using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreUI.Application.GenreOperations.Commands.CreateGenre;
using MovieStoreUI.Application.GenreOperations.Commands.DeletGenre;
using MovieStoreUI.Application.GenreOperations.Commands.UpdateGenre;
using MovieStoreUI.Application.GenreOperations.Queries.GetAllGenres;
using MovieStoreUI.Application.GenreOperations.Queries.GetGenreDetail;
using MovieStoreUI.DbOperations;


namespace MovieStoreUI.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class GenreController:ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GenreController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllGenres()
        {
            GetAllGenresQuery query = new GetAllGenresQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdGenre(int id)
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
            GetGenreDetailValidator validator = new GetGenreDetailValidator();
            query.GenreId = id;
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);
        }


        [HttpPost]
        public IActionResult CreateGenre(CreateGenreViewModel genreViewModel)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            CreateGenreValidator validator = new CreateGenreValidator();
            command.Model = genreViewModel;
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok("Tür Adı Eklendi");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre(UpdateGenreViewModel genreViewModel, int id)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            UpdateGenreValidator validator = new UpdateGenreValidator();
            command.GenreId = id;
            command.Model = genreViewModel;
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok("Tür Adı Güncellendi");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            DeleteGenreValidator validator = new DeleteGenreValidator();
            command.GenreId = id;
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok("Tür Adı Silindi");
        }
        
    }
}