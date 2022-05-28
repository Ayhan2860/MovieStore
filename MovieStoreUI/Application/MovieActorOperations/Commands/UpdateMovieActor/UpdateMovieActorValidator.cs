using FluentValidation;

namespace MovieStoreUI.Application.MovieActorOperations.Commands.UpdateMovieActor
{
    public class UpdateMovieActorValidator:AbstractValidator<UpdateMovieActorCommand>
    {
        public UpdateMovieActorValidator()
        {
            RuleFor(uma=>uma.MovieActorID).NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(uma=>uma.Model.ActorId).NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(uma=>uma.Model.MovieId).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}