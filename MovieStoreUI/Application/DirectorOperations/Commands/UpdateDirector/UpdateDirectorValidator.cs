using FluentValidation;

namespace MovieStoreUI.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorValidator:AbstractValidator<UpdateDirectorCommand>
    {
        public UpdateDirectorValidator()
        {
            RuleFor(d=>d.Model.FirstName).NotEmpty().MinimumLength(3);
            RuleFor(d=>d.Model.LastName).NotEmpty().MinimumLength(3);
            RuleFor(d=>d.DirectorId).NotEmpty().GreaterThan(0);
        }
    }
}