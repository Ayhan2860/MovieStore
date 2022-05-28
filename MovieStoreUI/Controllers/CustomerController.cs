using System;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieStoreUI.Application.CustomerOperations.Commands.CreateCustomer;
using MovieStoreUI.Application.CustomerOperations.Commands.CreateToken;
using MovieStoreUI.Application.CustomerOperations.Commands.RefreshToken;
using MovieStoreUI.Application.CustomerOperations.Queries.GetCustomerDetail;
using MovieStoreUI.Application.TokenOperations.Models;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class CustomerController:ControllerBase
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CustomerController(IMovieStoreDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Register([FromBody] CreateCustomerViewModel customer)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(_dbContext, _mapper);
            CreateCustomerValidation validator = new CreateCustomerValidation();
            command.Model = customer;
            validator.ValidateAndThrow(command);
            var result = command.Handle();
            
            CreateTokenModel tokenModel = new CreateTokenModel { Email = customer.Email, Password = customer.Password };
       
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        

        [HttpPost("connect/token")]
        public IActionResult Login([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand commandToken = new CreateTokenCommand(_dbContext, _mapper, _configuration);
            CreateTokenValidator validator = new CreateTokenValidator();
            commandToken.Model = login;
            validator.ValidateAndThrow(commandToken);
            var result = commandToken.Handle();
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("token")]
        public IActionResult RefreshToken([FromQuery] string token)
        {
            RefreshTokenCommand query = new RefreshTokenCommand(_dbContext, _configuration);
            query.RefreshToken = token;
            var result = query.Handle();
            if(result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }
        

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            GetCustomerDetailQuery query = new GetCustomerDetailQuery(_dbContext, _mapper);
            query.CustomerId =  id;
            var result = query.Handle();
            if(result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
       

    }
}