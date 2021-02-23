using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.Validation.FluentValidation
{
    public class FulModelValidator : AbstractValidator<Model>
    {
        public FulModelValidator()
        {
            RuleFor(m => m.ModelId).Empty();
            RuleFor(m => m.ModelName).NotEmpty().WithMessage("Please enter {Propertyname}");
            RuleFor(m => m.ModelName).Length(2, 50).WithMessage("Please enter {Propertyname} between 2 and 50 characters");
            RuleFor(m => m.BrandId).NotEmpty().WithMessage("Please enter a brand Id");
            RuleFor(m => m.BrandId).GreaterThan(0).WithMessage("Please enter a valid brand Id");
        }
    }
}
