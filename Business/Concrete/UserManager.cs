using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Validation.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation.Results;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private FulUserValidator _userValidator;
        private ValidationResult _validationResult;

        public UserManager(IUserDal userDal)
        {
            _userValidator = new FulUserValidator();
            _userDal = userDal;
        }
        public IDataResult<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult("Successfully Added.");
        }

        public IResult Delete(User user)
        {
            throw new NotImplementedException();
        }

        public IResult Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
