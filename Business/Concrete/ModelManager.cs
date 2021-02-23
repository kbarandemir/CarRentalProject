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
    public class ModelManager : IModelService
    {
        private IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }
        [ValidationAspect(typeof(FulModelValidator))]
        public IResult Add(Model model)
        {
            _modelDal.Add(model);
            return new SuccessResult(Messages.ModelAdded);
        }

        public IResult Delete(Model model)
        {
            var modelToDelete = _modelDal.Get(m => m.ModelId == model.ModelId);
            if (modelToDelete.ModelId>0)
            {
                return new SuccessResult(Messages.ModelDeleted);
            }
            else
            {
                return new ErrorResult(Messages.ModelNotFound);
            }
        }

        public IDataResult<List<Model>> GetAll()
        {
            var result = _modelDal.GetAll();
            if (result.Count>0)
            {
                return new SuccessDataResult<List<Model>>(result, Messages.ModelsListed);
            }
            else
            {
                return new ErrorDataResult<List<Model>>(Messages.NoModelToList);
            }
        }
        [ValidationAspect(typeof(FulModelValidator))]
        public IResult Update(Model model)
        {
            var modelToUpdate = _modelDal.Get(m => m.ModelId == model.ModelId);
            modelToUpdate.BrandId = model.BrandId;
            modelToUpdate.ModelName = model.ModelName;
            _modelDal.Update(modelToUpdate);
            return new SuccessResult(Messages.ModelUpdated);
        }
    }
}
