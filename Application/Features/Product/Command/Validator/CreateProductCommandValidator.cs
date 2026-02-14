using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Product.Command.Validator
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty().WithMessage("Name Cannot Be Blank")
            .Length(2, 25).WithMessage("Length Maximum 25 and Minimum 2");


        }
    }
}
