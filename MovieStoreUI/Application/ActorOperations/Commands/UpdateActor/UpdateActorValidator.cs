using FluentValidation;

namespace MovieStoreUI.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorValidator:AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorValidator()
        {
            RuleFor(a=>a.Model.FirstName).NotEmpty();
            RuleFor(a=>a.Model.LastName).NotEmpty();

            RuleFor(a=>a.Model.FirstName).MinimumLength(3);
            RuleFor(a=>a.Model.LastName).MinimumLength(3);

            RuleFor(a=>a.ActorId).NotEmpty();
            RuleFor(a=>a.ActorId).GreaterThan(0);
        }
    }
}