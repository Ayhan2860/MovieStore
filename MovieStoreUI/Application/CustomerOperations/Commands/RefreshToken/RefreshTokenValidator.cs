using FluentValidation;

namespace MovieStoreUI.Application.CustomerOperations.Commands.RefreshToken
{
    public class RefreshTokenValidator:AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenValidator()
        {
            RuleFor(rt=>rt.RefreshToken).NotEmpty();
          
        }
    }
}