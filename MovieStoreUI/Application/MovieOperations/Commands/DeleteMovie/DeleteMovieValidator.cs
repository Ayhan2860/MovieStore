using FluentValidation;

namespace MovieStoreUI.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieValidator:AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMovieValidator()
        {
            RuleFor(mv=>mv.MovieId).NotEmpty().GreaterThan(0);
        }
    }
}