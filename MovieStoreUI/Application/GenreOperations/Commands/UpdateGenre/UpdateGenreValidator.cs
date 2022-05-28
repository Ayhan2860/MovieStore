using FluentValidation;

namespace MovieStoreUI.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreValidator:AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreValidator()
        {
            RuleFor(g=>g.GenreId).NotEmpty().GreaterThan(0);
            RuleFor(g=>g.Model.Name).NotEmpty().MinimumLength(3);
        }   
    }
}