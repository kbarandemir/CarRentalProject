using Business.Abstract;
using Business.Constant;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        ICarService _carService;
        ICarImageFileService _carImageFileService;

        public CarImageManager(ICarImageDal carImageDal, ICarImageFileService carImageFileService, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
            _carImageFileService = carImageFileService;
        }

        public IResult Add(IFormFile file, int carId)
        {
            var result = BusinessRules.Run(CheckCarImageExceeded(carId), ChechCarExisted(carId));
            if (result!=null)
            {
                return null;
            }
            string path = Guid.NewGuid().ToString() + new FileInfo(file.FileName).Extension;
            var carImage = new CarImage {
                CarId = carId,
                DateOfImage = DateTime.Now,
                ImagePath = path
            };
            _carImageFileService.Add(path, file);
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(string path)
        {
            _carImageFileService.Delete(path);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IResult Update(IFormFile file, int carId)
        {
            throw new NotImplementedException();
        }

        private IResult ChechCarExisted(int carId)
        {
            var result = _carService.GetCarById(carId);
            if (result.Success)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarNotFound);
        }
        private IResult CheckCarImageExceeded(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (result>5)
            {
                return new ErrorResult(Messages.ImagesExceeded);
            }
            return new SuccessResult();
        }
    }
}
