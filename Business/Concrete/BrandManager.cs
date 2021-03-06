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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public IDataResult<List<Brand>> GetAll()
        {
            var data = _brandDal.GetAll();
            if (data.Count > 0)
            {
                return new SuccessDataResult<List<Brand>>(data, Messages.BrandsListed);
            }
            return new ErrorDataResult<List<Brand>>(Messages.NoBrandToList);


        }
        [ValidationAspect(typeof(FulBrandValidator))]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            Brand brandToDelete = _brandDal.Get(b => b.BrandId == brand.BrandId);
            _brandDal.Delete(brandToDelete);
            return new SuccessResult(Messages.BrandDeleted);
        }
        [ValidationAspect(typeof(FulBrandValidator))]
        public IResult Update(Brand brand)
        {
            Brand brandToUpdate = _brandDal.Get(b => b.BrandId == brand.BrandId);
            brandToUpdate.BrandName = brand.BrandName;
            _brandDal.Update(brandToUpdate);
            return new SuccessResult(Messages.BrandUpdated);

        }
    }
}
