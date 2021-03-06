using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageFileService
    {
        IResult Add(string filePath, IFormFile file);
        IResult Delete(string path);
        //IResult Update(string filePath, IFormFile file);  
    }
}
