using FluentValidation;

namespace MovieStoreUI.Application.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailValidator:AbstractValidator<GetActorDetailQuery>
    {
        public GetActorDetailValidator()
        {
            RuleFor(a=>a.ActorId).NotEmpty();
            RuleFor(a=>a.ActorId).GreaterThan(0);
        }
    }
}