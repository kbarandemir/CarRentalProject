using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<CarDetailDto>> GetAll();
        IDataResult<List<CarDetailDto>> GetCarsByBrandName(string brandName);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
    }
}
