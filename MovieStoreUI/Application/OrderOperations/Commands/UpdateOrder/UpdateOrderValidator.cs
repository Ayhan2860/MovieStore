using FluentValidation;

namespace MovieStoreUI.Application.OrderOperations.Commands.UpdateOrder
{
    public class UpdateOrderValidator:AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderValidator()
        {
            RuleFor(o=>o.OrderId).NotEmpty().GreaterThan(0);
            RuleFor(o => o.Model.CustomerId).NotEmpty().GreaterThan(0);
            RuleFor(o => o.Model.MovieId).NotEmpty().GreaterThan(0);
            RuleFor(o => o.Model.OrderPrice).NotEmpty().GreaterThan(10);
        }
    }
}