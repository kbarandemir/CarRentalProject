using System;
using System.Collections.Generic;
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
    public class CarBodyManager : ICarBodyService
    {
        private ICarBodyDal _carBodyDal;
        public CarBodyManager(ICarBodyDal carBodyDal)
        {
            _carBodyDal = carBodyDal;
        }
        public IDataResult<List<CarBody>> GetAll()
        {
            var result = _carBodyDal.GetAll();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarBody>>(result, Messages.CarBodiesListed);
            }
            return new ErrorDataResult<List<CarBody>>(Messages.NoCarBodyToList);

        }
        [ValidationAspect(typeof(FulCarBodyValidator))]
        public IResult Add(CarBody carBody)
        {
            _carBodyDal.Add(carBody);
            return new SuccessResult(Messages.CarBodyAdded);
        }

        public IResult Delete(CarBody carBody)
        {
            var carBodyToDelete = _carBodyDal.Get(c => c.CarBodyId == carBody.CarBodyId);
            if (carBodyToDelete.CarBodyId > 0)
            {
                return new SuccessResult(Messages.CarBodyDeleted);
            }
            return new ErrorResult(Messages.CarBodyNotFound);

        }

        [ValidationAspect(typeof(FulCarBodyValidator))]
        public IResult Update(CarBody carBody)
        {
            var carBodyToUpdate = _carBodyDal.Get(c => c.CarBodyId == carBody.CarBodyId);
            carBodyToUpdate.CarBodyName = carBody.CarBodyName;
            _carBodyDal.Update(carBodyToUpdate);
            return new SuccessResult();
        }
    }
}
