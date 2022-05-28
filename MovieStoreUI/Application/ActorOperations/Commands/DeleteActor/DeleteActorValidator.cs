using FluentValidation;

namespace MovieStoreUI.Application.ActorOperations.Commands.DeleteActor
{
   public class DeleteActorValidator:AbstractValidator<DeleteActorCommand>
    {
        public DeleteActorValidator()
        {
            RuleFor(a=>a.ActorId).NotEmpty();
            RuleFor(a=>a.ActorId).GreaterThan(0);
        }
    }
}