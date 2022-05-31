using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreUI.Application.DirectorOperations.Commands.CreateDirector;
using MovieStoreUI.Application.DirectorOperations.Commands.DeleteDirector;
using MovieStoreUI.Application.DirectorOperations.Commands.UpdateDirector;
using MovieStoreUI.Application.DirectorOperations.Queries.GetDirectorDetail;
using MovieStoreUI.Application.DirectorOperations.Queries.GetDirectors;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class DirectorController:ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public DirectorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDirectors()
        {
            GetDirectorsQueries query = new GetDirectorsQueries(_context, _mapper);
            var result = query.Handle();
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetDirectorDetailQuery query = new GetDirectorDetailQuery(_context, _mapper);
            GetDirectorDetailValidator validator = new GetDirectorDetailValidator();
            query.DirectorId =id;
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [HttpPost("create")]
        public IActionResult CreateDirector(CreateDirectorViewModel director)
        {
            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper);
            CreateDirectorValidator validator = new CreateDirectorValidator();
            command.Model = director;
            validator.ValidateAndThrow(command);
            var result = command.Handle();
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDirector(UpdateDirectorViewModel director, int id)
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context);
            UpdateDirectorValidator validator  = new UpdateDirectorValidator();
            command.DirectorId = id;
            command.Model = director;
            validator.Validate(command);
            var result = command.Handle();
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDirector(int id)
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
            DeleteDirectorValidator validator = new DeleteDirectorValidator();
            command.DirectorId = id;
            validator.ValidateAndThrow(command);
            var result = command.Handle();
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}