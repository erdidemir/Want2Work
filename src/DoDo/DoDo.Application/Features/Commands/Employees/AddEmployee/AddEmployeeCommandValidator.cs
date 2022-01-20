using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Application.Features.Commands.Employees.AddEmployee
{
    public class AddEmployeeCommandValidator : AbstractValidator<AddEmployeeCommand>
    {
        public AddEmployeeCommandValidator()
        {
            RuleFor(p => p.UserId)
               .NotEmpty().WithMessage("{UserId} is required.");

            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{FirstName} is required.");

            RuleFor(p => p.LastName)
              .NotEmpty().WithMessage("{LastName} is required.");

        }
    }
}
