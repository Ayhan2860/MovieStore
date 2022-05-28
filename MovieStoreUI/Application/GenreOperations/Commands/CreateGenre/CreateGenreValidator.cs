using FluentValidation;

namespace MovieStoreUI.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreValidator:AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreValidator()
        {
            RuleFor(g=>g.Model.Name).NotEmpty().MinimumLength(3);
        }
    }
}