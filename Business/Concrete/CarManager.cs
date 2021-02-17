using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using Business.Constant;
using Business.Validation.FluentValidation;
using FluentValidation.Results;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        FulCarValidator _carValidator;
        ValidationResult _validationResult;
        public CarManager(ICarDal carDal)
        {
            _carValidator = new FulCarValidator();
            _carDal = carDal;
        }
        public IResult Add(Car car)
        {
            _validationResult = _carValidator.Validate(car);
            if (!_validationResult.IsValid)
            {
                return new ErrorResult(_validationResult.Errors.ToString());
            }
            else
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
        }

        public IResult Delete(Car car)
        {
            Car carToDelete = _carDal.Get(c => c.CarId == car.CarId);
            _carDal.Delete(carToDelete);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<CarDetailDto>> GetAll()
        {
            var data = _carDal.GetCarDetailDto();
            if (data.Count>0)
            {
                return new SuccessDataResult<List<CarDetailDto>>(data, Messages.CarsListed);
            }
            else
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.NoCarToList);
            }
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandName(string brandName)
        {
            var data = _carDal.GetCarDetailDto(c =>
                c.BrandName.ToUpper() == brandName.ToUpper());
            if (data.Count>0)
            {
                return new SuccessDataResult<List<CarDetailDto>>(data, Messages.CarsListed);
            }
            else
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.NoCarToList);
            }
        }

        public IResult Update(Car car)
        {
            _validationResult = _carValidator.Validate(car);
            if (!_validationResult.IsValid)
            {
                return new ErrorResult(_validationResult.Errors.ToString());
            }
            else
            {
                Car carToUpdate = _carDal.Get(c => c.CarId == car.CarId);
                carToUpdate.BrandId = car.BrandId;
                carToUpdate.ModelId = car.ModelId;
                carToUpdate.Transmission = car.Transmission;
                carToUpdate.CarBodyId = car.CarBodyId;
                carToUpdate.ModelYear = car.ModelYear;
                carToUpdate.DailyPrice = car.DailyPrice;
                carToUpdate.ColorId = car.ColorId;
                _carDal.Update(carToUpdate);
                return new SuccessResult(Messages.CarUpdated);
            }
        }
    }
}
