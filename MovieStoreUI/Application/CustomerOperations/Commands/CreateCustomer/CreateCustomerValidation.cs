using FluentValidation;

namespace MovieStoreUI.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerValidation:AbstractValidator<CreateCustomerCommand>
    {
       public CreateCustomerValidation()
       {
           RuleFor(c=>c.Model.FirstName).NotEmpty().MinimumLength(3);
           RuleFor(c=>c.Model.LastName).NotEmpty().MinimumLength(3);
           RuleFor(c=>c.Model.Email).NotEmpty();
           RuleFor(c=>c.Model.Password).NotEmpty();
           RuleFor(c=>c.Model.Email).EmailAddress();
           RuleFor(c=>c.Model.Password).MinimumLength(6);
       }
    }
}