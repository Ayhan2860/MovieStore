using FluentValidation;

namespace MovieStoreUI.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderValidator:AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            RuleFor(o=>o.Model.CustomerId).NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(o =>o.Model.MovieId).NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(o=>o.Model.OrderPrice).NotEmpty().GreaterThan(10);
        }
    }
}