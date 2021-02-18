using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.Validation.FluentValidation
{
    public class FulCarValidator : AbstractValidator<Car>, IValidator
    {
        public FulCarValidator()
        {
            //RuleFor(car => car.BrandId).NotNull().WithMessage("Please enter a {Propertyname}.");
            //RuleFor(car => car.BrandId).LessThan(0).WithMessage("{Propertyname} should be more than 0.");

            //RuleFor(car => car.ModelId).NotNull().WithMessage("Please enter a {Propertyname}.");
            //RuleFor(car => car.ModelId).LessThan(0).WithMessage("Please enter valuable a price.");

            //RuleFor(car => car.Transmission).NotNull().WithMessage("Please enter a {Propertyname}.");

            //RuleFor(car => car.CarBodyId).NotNull().WithMessage("Please enter a {Propertyname}.");
            //RuleFor(car => car.CarBodyId).LessThan(0).WithMessage("Please enter a number more than 0.");

            //RuleFor(car => car.ColorId).NotNull().WithMessage("Please enter a {Propertyname}.");
            //RuleFor(car => car.ColorId).LessThan(0).WithMessage("Please enter a number more than 0.");

            //RuleFor(car => car.ModelYear).NotNull().WithMessage("Please enter a {Propertyname}.");
            //RuleFor(car => car.ModelYear).LessThan(1950).WithMessage("Please enter the year more than 1950");
            //RuleFor(car => car.ModelYear).GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("Please check your input and try again. ");

            //RuleFor(car => car.DailyPrice).NotNull().WithMessage("Please enter a {Propertyname}.");
            //RuleFor(car => car.DailyPrice).LessThan(0).WithMessage("Please enter correct value.");

        }
    }
}
