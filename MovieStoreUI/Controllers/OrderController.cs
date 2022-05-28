using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStoreUI.Application.OrderOperations.Commands.CreateOrder;
using MovieStoreUI.Application.OrderOperations.Commands.DeleteOrder;
using MovieStoreUI.Application.OrderOperations.Commands.UpdateOrder;
using MovieStoreUI.Application.OrderOperations.Queries.GetByCustomerIdOrderDetail;
using MovieStoreUI.Application.OrderOperations.Queries.GetDetailOrder;
using MovieStoreUI.DbOperations;

namespace MovieStoreUI.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    [Authorize]
    public class OrderController:ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public OrderController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateOrder(CreateOrderViewModel orderViewModel)
        {
            CreateOrderCommand command = new CreateOrderCommand(_context, _mapper);
            CreateOrderValidator validator = new CreateOrderValidator();
            command.Model = orderViewModel;
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok("Sipariş eklendi");
        }

        // [HttpPut("{id}")]
        // public IActionResult UpdateOrder(UpdateOrderViewModel orderViewModel, int id)
        // {
        //     UpdateOrderCommand command = new UpdateOrderCommand(_context);
        //     UpdateOrderValidator validate = new UpdateOrderValidator();
        //     command.OrderId = id;
        //     command.Model = orderViewModel;
        //     validate.ValidateAndThrow(command);
        //     command.Handle();
        //     return Ok("Sipariş Güncellendi");
            
        // }

        [HttpGet("{customerId}")]
        public IActionResult GetByCustomerIdOrderDetail(int customerId)
        {
            GetOrderByCustomerIdDetailQuery query = new GetOrderByCustomerIdDetailQuery(_context, _mapper);
            GetOrderByCustomerIdDetailValidator validate = new GetOrderByCustomerIdDetailValidator();
            query.CustomerId = customerId;
            validate.ValidateAndThrow(query);
            var result = query.Handle();

            return Ok(result);

        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetByIdOrderDetail(int id)
        {
            GetOrderDetailQuery query = new GetOrderDetailQuery(_context, _mapper);
            GetOrderDetailValidator validate = new GetOrderDetailValidator();
            query.OrderId = id;
            validate.ValidateAndThrow(query);
            var result = query.Handle();

            return Ok(result);

        }

        [HttpPut("orderDelete/{id}")]
        public IActionResult PassiveDelete(int id)
        {
            DeleteOrderCommand command = new DeleteOrderCommand(_context);
            DeleteOrderValidator validator = new DeleteOrderValidator();
            command.OrderId = id;
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok("silindi");

        }

    }
}