﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Application.Features.Commands.Jobbers.UpdateJobber
{
    public class UpdateJobberCommandValidator : AbstractValidator<UpdateJobberCommand>
    {
        public UpdateJobberCommandValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{FirstName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{FirstName} must not exceed 50 characters.");

            RuleFor(p => p.LastName)
              .NotEmpty().WithMessage("{LastName} is required.")
              .NotNull()
              .MaximumLength(50).WithMessage("{LastName} must not exceed 50 characters.");
        }
    }
}
