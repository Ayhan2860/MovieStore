using FluentValidation;

namespace MovieStoreUI.Application.GenreOperations.Commands.DeletGenre
{
    public class DeleteGenreValidator:AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreValidator()
        {
            RuleFor(g=>g.GenreId).NotEmpty().GreaterThan(0);
        }
    }
}