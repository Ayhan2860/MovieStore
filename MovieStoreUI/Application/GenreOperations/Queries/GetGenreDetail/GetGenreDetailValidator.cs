using FluentValidation;

namespace MovieStoreUI.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailValidator:AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreDetailValidator()
        {
            RuleFor(g => g.GenreId).NotEmpty().GreaterThan(0);
        }
    }
}