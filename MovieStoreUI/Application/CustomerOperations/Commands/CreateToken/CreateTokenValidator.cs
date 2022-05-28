using FluentValidation;

namespace MovieStoreUI.Application.CustomerOperations.Commands.CreateToken
{
    public class CreateTokenValidator:AbstractValidator<CreateTokenCommand>
    {
        public CreateTokenValidator()
        {
            RuleFor(t=>t.Model.Email).NotEmpty().EmailAddress();
            RuleFor(t=>t.Model.Password).NotEmpty().MinimumLength(6);
            
        }
    }
}