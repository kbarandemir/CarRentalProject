using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.Validation.FluentValidation
{
    public class FulRentalValidator : AbstractValidator<Rental>
    {
        public FulRentalValidator()
        {
            RuleFor(r => r.RentDate).NotEmpty();

            RuleFor(r => r.ReturnDate).NotEmpty();
        }
    }
}
