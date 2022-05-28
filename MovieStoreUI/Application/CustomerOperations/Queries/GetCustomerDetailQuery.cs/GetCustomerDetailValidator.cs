using FluentValidation;

namespace  MovieStoreUI.Application.CustomerOperations.Queries.GetCustomerDetail
{
  public  class GetCustomerDetailValidator:AbstractValidator<GetCustomerDetailQuery>
    {
        public GetCustomerDetailValidator()
        {
            RuleFor(cs => cs.CustomerId).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }    
}