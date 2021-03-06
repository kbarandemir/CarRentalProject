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
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<User>>(result);
            }
            return new ErrorDataResult<List<User>>();
        }
        [ValidationAspect(typeof(FulUserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult("Successfully Added.");
        }
        [ValidationAspect(typeof(FulUserValidator))]
        public IResult Delete(User user)
        {
            var userToDelete = _userDal.Get(u => u.UserId == user.UserId);
            if (userToDelete.Password == user.Password)
            {
                _userDal.Delete(userToDelete);
                return new SuccessResult(Messages.UserDeleted);
            }
            return new ErrorResult(Messages.UserNotFound);
        }
        [ValidationAspect(typeof(FulUserValidator))]
        public IResult Update(User user)
        {
            var userToUpdate = _userDal.Get(u => u.UserId == user.UserId);
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.Surname = user.Surname;
            userToUpdate.Email = user.Email;
            userToUpdate.DateOfBirth = user.DateOfBirth;
            userToUpdate.Password = user.Password;
            _userDal.Update(userToUpdate);
            return new SuccessResult();
        }

        public IDataResult<User> GetUserById(int userId)
        {
            var result = _userDal.Get(u => u.UserId == userId);
            if (result.UserId > 0)
            {
                return new SuccessDataResult<User>(result);
            }
            return new ErrorDataResult<User>(Messages.UserNotFound);
        }
    }
}
