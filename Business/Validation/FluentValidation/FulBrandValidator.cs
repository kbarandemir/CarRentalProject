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
            RuleFor(b => b.BrandName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter {Propertyname}")
                .Length(2, 50).WithMessage("Please enter {Propertyname} between 2 and 50 characters");
        }
    }
}
