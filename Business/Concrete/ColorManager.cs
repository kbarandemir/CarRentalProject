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
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;
        private FulColorValidator _colorValidator;
        private ValidationResult _validationResult;
        public ColorManager(IColorDal colorDal)
        {
            _colorValidator = new FulColorValidator();
            _colorDal = colorDal;
        }
        public IDataResult<List<Color>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult();
        }

        public IResult Delete(Color color)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Color color)
        {
            throw new NotImplementedException();
        }
    }
}
