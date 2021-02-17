using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Validation.FluentValidation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation.Results;

namespace Business.Concrete
{
    public class CarBodyManager : ICarBodyService
    {
        private ICarBodyDal _carBodyDal;
        private FulCarBodyValidator _carBodyValidator;
        private ValidationResult _validationResult;
        public CarBodyManager(ICarBodyDal carBodyDal)
        {
            _carBodyValidator = new FulCarBodyValidator();
            _carBodyDal = carBodyDal;
        }
        public IDataResult<List<CarBody>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Add(CarBody carBody)
        {
            _carBodyDal.Add(carBody);
            return new SuccessResult();
        }

        public IResult Delete(CarBody carBody)
        {
            throw new NotImplementedException();
        }

        public IResult Update(CarBody carBody)
        {
            throw new NotImplementedException();
        }
    }
}
