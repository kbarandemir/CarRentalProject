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
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var result = _customerDal.GetAll();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<Customer>>(result, Messages.CustomersListed);
            }
            else
            {
                return new ErrorDataResult<List<Customer>>(Messages.NoCustomerToList);
            }
        }

        [ValidationAspect(typeof(FulCustomerValidator))]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            var customerToDelete = _customerDal.Get(c => c.CustomerId == customer.CustomerId);
            if (customerToDelete.CustomerId > 0)
            {
                _customerDal.Delete(customerToDelete);
                return new SuccessResult(Messages.CustomerDeleted);
            }
            else
            {
                return new ErrorResult(Messages.CustomerNotFound);
            }

        }
        [ValidationAspect(typeof(FulCustomerValidator))]
        public IResult Update(Customer customer)
        {
            var customerToUpdate = _customerDal.Get(c => c.CustomerId == customer.CustomerId);
            customerToUpdate.CompanyName = customer.CompanyName;
            customerToUpdate.UserId = customer.UserId;
            _customerDal.Update(customerToUpdate);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
