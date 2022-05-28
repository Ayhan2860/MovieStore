using FluentValidation;

namespace MovieStoreUI.Application.OrderOperations.Queries.GetDetailOrder
{
    public class GetOrderDetailValidator:AbstractValidator<GetOrderDetailQuery>
    {
        public GetOrderDetailValidator()
        {
            RuleFor(o => o.OrderId).NotEmpty().GreaterThan(0);
        }
    }
}