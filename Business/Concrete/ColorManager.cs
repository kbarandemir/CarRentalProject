using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constant;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation.Results;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        [SecuredOperation("admin,moderator,user")]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }
        [SecuredOperation("admin,moderator")]
        [ValidationAspect(typeof(FulColorValidator))]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }
        [SecuredOperation("admin,moderator")]
        public IResult Delete(Color color)
        {
            var colorToDelete = _colorDal.Get(c => c.ColorId == color.ColorId);
            if (colorToDelete.ColorId > 0)
            {
                return new SuccessResult(Messages.ColorDeleted);
            }
            return new ErrorResult(Messages.ColorNotFound);

        }
        [SecuredOperation("admin,moderator")]
        [ValidationAspect(typeof(FulColorValidator))]
        public IResult Update(Color color)
        {
            var colorToUpdate = _colorDal.Get(c => c.ColorId == color.ColorId);
            colorToUpdate.ColorName = color.ColorName;
            _colorDal.Update(colorToUpdate);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
