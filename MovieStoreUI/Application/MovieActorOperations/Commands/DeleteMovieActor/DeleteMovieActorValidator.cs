using FluentValidation;

namespace MovieStoreUI.Application.MovieActorOperations.Commands.DeleteMovieActor
{
    public class DeleteMovieActorValidator:AbstractValidator<DeleteMovieActor>
    {
        public DeleteMovieActorValidator()
        {
            RuleFor(dma=> dma.MovieActorID).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}