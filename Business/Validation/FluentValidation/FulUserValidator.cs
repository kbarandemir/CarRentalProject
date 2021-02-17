using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.Validation.FluentValidation
{
    public class FulUserValidator :AbstractValidator<User>
    {
        public FulUserValidator()
        {
                
        }
    }
}
