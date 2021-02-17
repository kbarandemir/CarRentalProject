using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.Validation.FluentValidation
{
    public class FulColorValidator : AbstractValidator<Color>
    {
        public FulColorValidator()
        {
                
        }
    }
}
