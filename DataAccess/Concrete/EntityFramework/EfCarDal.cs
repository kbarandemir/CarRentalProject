using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetailDto(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (CarRentalProjectContext context = new CarRentalProjectContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands
                        on c.BrandId equals b.BrandId
                    join m in context.Models
                        on c.ModelId equals m.ModelId
                    join cb in context.CarBodies
                        on c.CarBodyId equals cb.CarBodyId
                    join cl in context.Colors
                        on c.ColorId equals cl.ColorId
                    select new CarDetailDto
                    {
                        CarId = c.CarId,
                        BrandName = b.BrandName,
                        ModelName = m.ModelName,
                        CarBodyName = cb.CarBodyName,
                        ColorName = cl.ColorName,
                        ModelYear = c.ModelYear,
                        DailyPrice = c.DailyPrice,
                        Transmission = c.Transmission

                    };

                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }
    }
}
