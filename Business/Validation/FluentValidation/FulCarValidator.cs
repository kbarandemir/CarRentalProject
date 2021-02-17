using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.Validation.FluentValidation
{   
    public class FulCarValidator :AbstractValidator<Car>,IValidator
    {
        public FulCarValidator()
        {
            RuleFor(car => car.CarId).Empty();

            RuleFor(car => car.BrandId)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Please enter a {Propertyname}.")
                .GreaterThan(0).WithMessage("{Propertyname} should be more than 0.");

            RuleFor(car => car.ModelId)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Please enter a {Propertyname}.")
                .GreaterThan(0).WithMessage("Please enter valuable a price.");

            RuleFor(car => car.Transmission)
                .NotNull().WithMessage("Please enter a {Propertyname}.");

            RuleFor(car => car.CarBodyId)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Please enter a {Propertyname}.")
                .GreaterThan(0).WithMessage("Please enter a number more than 0.");
            
            RuleFor(car => car.ColorId)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Please enter a {Propertyname}.")
                .GreaterThan(0).WithMessage("Please enter a number more than 0.");

            RuleFor(car => car.ModelYear)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Please enter a {Propertyname}.")
                .LessThan(1950).WithMessage("Please enter the year more than 1950")
                .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("Please check your input and try again. ");

            RuleFor(car => car.DailyPrice)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Please enter a {Propertyname}.")
                .GreaterThan(0).WithMessage("Please enter correct value.");
            
        }
    }
}
