using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constant;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using FluentValidation.Results;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userDal.GetClaims((user));
            if (result!=null)
            {
                return new SuccessDataResult<List<OperationClaim>>(Messages.UsersListed);
            }

            return new ErrorDataResult<List<OperationClaim>>(Messages.NoUserToList);
        }

        [ValidationAspect(typeof(FulUserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded); 
        }

        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);
            if (result!=null)
            {
                return new SuccessDataResult<User>(Messages.UserFound);
            }

            return new ErrorDataResult<User>(Messages.UserNotFound);
        }
    }
}
