using System.Collections.Generic;
using Business.Abstract;
using Business.Constant;
using Business.Validation.FluentValidation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation.Results;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        FulBrandValidator _brandValidator;
        ValidationResult _validationResult;
        public BrandManager(IBrandDal brandDal)
        {
            _brandValidator = new FulBrandValidator();
            _brandDal = brandDal;
        }
        public IDataResult<List<Brand>> GetAll()
        {
            var data = _brandDal.GetAll();
            if (data.Count>0)
            {
                return new SuccessDataResult<List<Brand>>(data,Messages.BrandsListed);
            }
            else
            {
                return new ErrorDataResult<List<Brand>>(Messages.NoBrandToList);
            }
            
        }

        public IResult Add(Brand brand)
        {
            _validationResult = _brandValidator.Validate(brand);
            if (!_validationResult.IsValid)
            {
                return new ErrorResult(_validationResult.Errors.ToString());
            }
            else
            {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.BrandAdded);
            }
        }

        public IResult Delete(Brand brand)
        {
            Brand brandToDelete = _brandDal.Get(b => b.BrandId == brand.BrandId);
            _brandDal.Delete(brandToDelete);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IResult Update(Brand brand)
        {
            _validationResult = _brandValidator.Validate(brand);
            if (!_validationResult.IsValid)
            {
                return new ErrorResult(_validationResult.Errors.ToString());
            }
            else
            {
                Brand brandToUpdate = _brandDal.Get(b => b.BrandId == brand.BrandId);
                brandToUpdate.BrandName = brand.BrandName;
                _brandDal.Update(brandToUpdate);
                return new SuccessResult(Messages.BrandUpdated);
            }
        }
    }
}
