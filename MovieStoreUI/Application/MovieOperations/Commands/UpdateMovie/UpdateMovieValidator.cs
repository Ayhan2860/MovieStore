using System;
using FluentValidation;

namespace MovieStoreUI.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieValidator:AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieValidator()
        {
            RuleFor(mv=>mv.MovieId).NotEmpty().GreaterThan(0);
            RuleFor(mv=>mv.Model.DirectorId).NotEmpty().GreaterThan(0);
            RuleFor(mv=>mv.Model.Title).NotEmpty().MinimumLength(3);
            RuleFor(mv=>mv.Model.GenreId).NotEmpty().GreaterThan(0);
            RuleFor(mv=>mv.Model.ReleaseDate).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(mv=>mv.Model.Price).NotEmpty().GreaterThan(0);
        }
    }
}