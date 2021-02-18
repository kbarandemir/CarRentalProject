using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.Validation.FluentValidation
{
    public class FulBrandValidator : AbstractValidator<Brand>
    {
        public FulBrandValidator()
        {
            RuleFor(b => b.BrandId).Empty();

            RuleFor(b => b.BrandName).NotEmpty().WithMessage("Please enter {Propertyname}");
            RuleFor(b => b.BrandName).Length(2, 50).WithMessage("Please enter {Propertyname} between 2 and 50 characters");
        }
    }
}
