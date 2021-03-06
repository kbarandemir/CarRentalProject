using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constant;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation.Results;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IDataResult<List<Rental>> GetAll()
        {
            var result = _rentalDal.GetAll();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<Rental>>(result, Messages.RentalsListed);
            }
            return new ErrorDataResult<List<Rental>>(Messages.NoRentalToList);
        }
        [ValidationAspect(typeof(FulRentalValidator))]
        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            var resultToDelete = _rentalDal.Get(r => r.RentalId == rental.RentalId);
            if (resultToDelete.RentalId > 0)
            {
                return new SuccessResult(Messages.RentalDeleted);
            }
            return new ErrorResult(Messages.RentalNotFound);
        }
        [ValidationAspect(typeof(FulRentalValidator))]
        public IResult Update(Rental rental)
        {
            var rentalToUpdate = _rentalDal.Get(r => r.RentalId == rental.RentalId);
            rentalToUpdate.CarId = rental.CarId;
            rentalToUpdate.CustomerId = rental.CustomerId;
            rentalToUpdate.RentDate = rental.RentDate;
            rentalToUpdate.ReturnDate = rental.ReturnDate;
            _rentalDal.Update(rentalToUpdate);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
