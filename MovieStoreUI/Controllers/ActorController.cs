using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreUI.Application.ActorOperations.Commands.CreateActor;
using MovieStoreUI.Application.ActorOperations.Commands.DeleteActor;
using MovieStoreUI.Application.ActorOperations.Commands.UpdateActor;
using MovieStoreUI.Application.ActorOperations.Queries.GetActorDetail;
using MovieStoreUI.Application.ActorOperations.Queries.GetActors;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class ActorController:ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public ActorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetActors()
        {
            GetActorQueries query = new GetActorQueries(_context, _mapper);
            var result = query.Handle();
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetActorDetail(int id)
        {
            GetActorDetailQuery query = new GetActorDetailQuery(_context, _mapper);
            GetActorDetailValidator validator = new GetActorDetailValidator();
            
            query.ActorId = id;
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            if(result.Success)
                return Ok(result);
            else 
                return BadRequest(result.Message);
        }

        [HttpPost]
        public IActionResult CreateActor([FromBody]CreateActorViewModel actor)
        {
            CreateActorCommand command = new CreateActorCommand(_context, _mapper);
            CreateActorValidator validator = new CreateActorValidator();
            command.Model = actor;
            validator.ValidateAndThrow(command);
            command.Handle();
            var result =  command.Handle();
            if(result.Success)
                return Ok(result);
            else 
                return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateActor([FromBody] UpdateActorViewModel actor, int id)
        {
            UpdateActorCommand command = new UpdateActorCommand(_context);
            UpdateActorValidator validator = new UpdateActorValidator();
            command.ActorId = id;
            command.Model = actor;
            validator.ValidateAndThrow(command);
            var result =   command.Handle();
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActor(int id)
        {
            DeleteActorCommand command = new DeleteActorCommand(_context);
            DeleteActorValidator validator = new DeleteActorValidator();
            command.ActorId = id;
            validator.ValidateAndThrow(command);
            var result = command.Handle();
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}