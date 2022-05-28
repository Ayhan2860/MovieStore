using FluentValidation;

namespace MovieStoreUI.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorValidator:AbstractValidator<DeleteDirectorCommand>
    {
        public DeleteDirectorValidator()
        {
            RuleFor(d=>d.DirectorId).NotEmpty().GreaterThan(0);
            
        }
    }
}