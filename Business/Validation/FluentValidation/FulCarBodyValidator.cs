using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.Validation.FluentValidation
{
    public class FulCarBodyValidator : AbstractValidator<CarBody>
    {
        public FulCarBodyValidator()
        {
            RuleFor(cb => cb.CarBodyName).NotEmpty();
            RuleFor(cb => cb.CarBodyName).Length(2, 20);
        }
    }
}
