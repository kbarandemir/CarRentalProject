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
            RuleFor(u => u.DateOfBirth).Must(MustBeMoreThan18);
        }

        private bool MustBeMoreThan18(DateTime arg)
        {
            if ((DateTime.Now-arg).TotalDays >= 18*365)
            {
                return true;
            }
            return false;
        }
    }
}
