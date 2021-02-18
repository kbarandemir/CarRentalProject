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
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;
        private FulCustomerValidator _customerValidator;
        private ValidationResult _validationResult;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerValidator = new FulCustomerValidator();
            _customerDal = customerDal;
        }

        public IDataResult<List<Customer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
