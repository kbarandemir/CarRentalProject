using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarBodiesController : Controller
    {
        ICarBodyService _carBodyservice;

        public CarBodiesController(ICarBodyService carBodyservice)
        {
            _carBodyservice = carBodyservice;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carBodyservice.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("add")]
        public IActionResult Add(CarBody carBody)
        {
            var result = _carBodyservice.Add(carBody);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpPost("delete")]
        public IActionResult Delete(CarBody carBody)
        {
            var result = _carBodyservice.Delete(carBody);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpPost("update")]
        public IActionResult Update(CarBody carBody)
        {
            var result = _carBodyservice.Update(carBody);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
