using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarBodyService
    {
        IDataResult<List<CarBody>> GetAll();
        IResult Add(CarBody carBody);
        IResult Delete(CarBody carBody);
        IResult Update(CarBody carBody);
    }
}
