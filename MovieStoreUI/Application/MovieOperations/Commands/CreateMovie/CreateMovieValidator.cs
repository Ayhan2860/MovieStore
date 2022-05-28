using System;
using FluentValidation;

namespace MovieStoreUI.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieValidator:AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieValidator()
        {
            RuleFor(mv=>mv.Model.DirectorId).NotEmpty().GreaterThan(0);
            RuleFor(mv=>mv.Model.Title).NotEmpty().MinimumLength(3);
            RuleFor(mv=>mv.Model.GenreId).NotEmpty().GreaterThan(0);
            RuleFor(mv=>mv.Model.ReleaseDate).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(mv=>mv.Model.Price).NotEmpty().GreaterThan(0);
        }
    }
}