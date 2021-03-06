using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validation.FluentValidation
{
    public class FulCarImageValidator : AbstractValidator<CarImage>
    {
        public FulCarImageValidator()
        {
            //RuleFor(p=>p.CarImageName);
        }
    }
}
