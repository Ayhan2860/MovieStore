using FluentValidation;

namespace MovieStoreUI.Application.OrderOperations.Commands.UpdateOrder
{
    public class UpdateOrderValidator:AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderValidator()
        {
            RuleFor(o=>o.OrderId).NotEmpty().GreaterThan(0);
        }
    }
}