using FluentValidation;

namespace MovieStoreUI.Application.DirectorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailValidator:AbstractValidator<GetDirectorDetailQuery>
    {
        public GetDirectorDetailValidator()
        {
            RuleFor(d=>d.DirectorId).NotEmpty().WithMessage("Id Numarası Boş Olamaz!").GreaterThan(0).WithMessage("Id Numarası 0'dan Büyük Olmalı!");
        }
    }
}