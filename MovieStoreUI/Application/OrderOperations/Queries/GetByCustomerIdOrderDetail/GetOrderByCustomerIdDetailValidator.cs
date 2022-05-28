using FluentValidation;

namespace MovieStoreUI.Application.OrderOperations.Queries.GetByCustomerIdOrderDetail
{
    public class GetOrderByCustomerIdDetailValidator:AbstractValidator<GetOrderByCustomerIdDetailQuery>
    {
        public GetOrderByCustomerIdDetailValidator()
        {
             RuleFor(o => o.CustomerId).NotEmpty().GreaterThan(0);
        }
    }
}