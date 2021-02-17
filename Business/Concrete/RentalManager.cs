using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Validation.FluentValidation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation.Results;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;
        private FulRentalValidator _rentalValidator;
        private ValidationResult _validationResult;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalValidator = new FulRentalValidator();
            _rentalDal = rentalDal;
        }
        public IDataResult<List<Rental>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Add(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Rental rental)
        {
            throw new NotImplementedException();
        }
    }
}
