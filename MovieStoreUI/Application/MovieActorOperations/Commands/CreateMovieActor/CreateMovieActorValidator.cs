using FluentValidation;

namespace MovieStoreUI.Application.MovieActorOperations.Commands.CreateMovieActor
{
    public class CreateMovieActorValidator:AbstractValidator<CreateMovieActorCommand>
    {
        public CreateMovieActorValidator()
        {
            RuleFor(ma=>ma.Model.ActorId).NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(ma=>ma.Model.MovieId).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}