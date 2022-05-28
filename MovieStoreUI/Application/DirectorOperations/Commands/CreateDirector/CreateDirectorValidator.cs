using FluentValidation;

namespace MovieStoreUI.Application.DirectorOperations.Commands.CreateDirector
{
     public class CreateDirectorValidator:AbstractValidator<CreateDirectorCommand>
     {
         public CreateDirectorValidator()
         {
             RuleFor(d=>d.Model.FirstName).NotEmpty().MinimumLength(3);
             RuleFor(d=>d.Model.LastName).NotEmpty().MinimumLength(3);
             
         }
     }
}