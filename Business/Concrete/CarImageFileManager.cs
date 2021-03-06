using Business.Abstract;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageFileManager : ICarImageFileService
    {
        private string Path = Environment.CurrentDirectory + @"\CarImages\";
        public CarImageFileManager()
        {

        }

        public IResult Add(string filePath, IFormFile file)
        {
            var tempPath = Path + filePath;
            if (file.Length > 0)
            {
                using (var stream = new FileStream(tempPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            if (!File.Exists(tempPath))
            {
                return new ErrorResult();
            }
            return new SuccessResult();

        }

        public IResult Delete(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new ErrorResult("Dosya Bulunamadı.");
            }
            File.Delete(filePath);
            return new SuccessResult();
        }


    }
}
