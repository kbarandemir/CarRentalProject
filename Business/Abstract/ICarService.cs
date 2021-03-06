using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll2();
        IDataResult<List<CarDetailDto>> GetAll();
        IDataResult<List<CarDetailDto>> GetCarsByBrandName(string brandName);
        IDataResult<Car> GetCarById(int carId);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
    }
}
