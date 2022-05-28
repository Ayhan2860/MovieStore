using FluentValidation;

namespace MovieStoreUI.Application.OrderOperations.Commands.DeleteOrder
{
    public class DeleteOrderValidator:AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderValidator()
        {
            RuleFor(o => o.OrderId).NotEmpty().GreaterThan(0);
        }
    }
}