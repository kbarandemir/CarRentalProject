using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Validation.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation.Results;

namespace Business.Concrete
{
    public class ModelManager : IModelService
    {
        private IModelDal _modelDal;
        private FulModelValidator _modelValidator;
        private ValidationResult _validationResult;

        public ModelManager(IModelDal modelDal)
        {
            _modelValidator = new FulModelValidator();
            _modelDal = modelDal;
        }
        public IResult Add(Model model)
        {
            _modelDal.Add(model);
            return new SuccessResult();
        }

        public IResult Delete(Model model)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Model>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Model model)
        {
            throw new NotImplementedException();
        }
    }
}
