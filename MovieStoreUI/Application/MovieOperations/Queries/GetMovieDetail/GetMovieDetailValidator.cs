using FluentValidation;

namespace MovieStoreUI.Application.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailValidator:AbstractValidator<GetMovieDetailQuery>
    {
        public GetMovieDetailValidator()
        {
            RuleFor(movie => movie.MovieId).NotEmpty().GreaterThan(0);
        }
    }
}