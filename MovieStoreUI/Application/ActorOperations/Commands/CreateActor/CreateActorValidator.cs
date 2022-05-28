using FluentValidation;

namespace MovieStoreUI.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorValidator:AbstractValidator<CreateActorCommand>
    {
        public CreateActorValidator()
        {
            RuleFor(a=>a.Model.FirstName).NotEmpty().MinimumLength(3);
             RuleFor(a=>a.Model.LastName).NotEmpty().MinimumLength(3);
        }
    }
}