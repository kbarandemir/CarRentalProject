using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using Business.BusinessAspects.Autofac;
using Business.Constant;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Caching;
using FluentValidation.Results;
using FluentValidation;
using Core.Aspects.Autofac.Validation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("car.add,admin,moderator")]
        [ValidationAspect(typeof(FulCarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        [SecuredOperation("admin,moderator")]
        public IResult Delete(Car car)
        {
            Car carToDelete = _carDal.Get(c => c.CarId == car.CarId);
            if (carToDelete.CarId > 0)
            {
                _carDal.Delete(carToDelete);
                return new SuccessResult(Messages.CarDeleted);
            }
            return new ErrorResult(Messages.CarNotFound);
        }
        [SecuredOperation("admin,moderator,user")]
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetAllCarDetail()
        {
            var data = _carDal.GetCarDetailDto();
            if (data.Count > 0)
            {
                return new SuccessDataResult<List<CarDetailDto>>(data, Messages.CarsListed);
            }
            return new ErrorDataResult<List<CarDetailDto>>(Messages.NoCarToList);
        }
        [SecuredOperation("admin,moderator,user")]
        public IDataResult<List<Car>> GetAll()
        {
            var data = _carDal.GetAll();
            if (data.Count > 0)
            {
                return new SuccessDataResult<List<Car>>(data, Messages.CarsListed);
            }
            return new ErrorDataResult<List<Car>>(Messages.NoCarToList);

        }
        [SecuredOperation("admin,moderator")]
        [CacheAspect]
        public IDataResult<Car> GetCarById(int carId)
        {
            var data = _carDal.Get(c => c.CarId == carId);
            if (data!=null)
            {
                return new SuccessDataResult<Car>(data);
            }
            return new ErrorDataResult<Car>(Messages.CarNotFound);
        }
        [SecuredOperation("admin,moderator,user")]
        public IDataResult<List<CarDetailDto>> GetCarsByBrandName(string brandName)
        {
            var data = _carDal.GetCarDetailDto(c =>
                c.BrandName.ToUpper() == brandName.ToUpper());
            if (data.Count > 0)
            {
                return new SuccessDataResult<List<CarDetailDto>>(data, Messages.CarsListed);
            }
            return new ErrorDataResult<List<CarDetailDto>>(Messages.NoCarToList);

        }
        [SecuredOperation("admin,moderator")]
        [ValidationAspect(typeof(FulCarValidator))]
        public IResult Update(Car car)
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
