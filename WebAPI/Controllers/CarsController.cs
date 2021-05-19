using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
       // [Authorize(Roles="car.list")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //-----------------------------------------
        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //----------------------------------------
        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("getcardetailsbybrandid")]
        public IActionResult GetCarDetailByBrandId(int brandId)
        {
            var result = _carService.GetCarDetailsByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcardetailsbycolorid")]
        public IActionResult GetCarDetailsByColorId(int colorId)
        {
            var result = _carService.GetCarDetailsByColorId(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarsbybranid")]
        public IActionResult GetCarsByBrandId(int brandId)
        {
            var result = _carService.GetCarsByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarsbycolorid")]
        public IActionResult GetCarsByColorId(int colorId)
        {
            var result = _carService.GetCarsByColorId(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    
        [HttpGet("getbydailyprice")]
        public IActionResult GetByDailyPrice(decimal min,decimal max)
        {
            var result = _carService.GetByDailyPrice(min, max);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcardetail")]
        public IActionResult GetCarDetail()
        {
            var result = _carService.GetCarDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcardetailbybrandname")]
        public IActionResult GetCarDetailByBrandName(string brandName)
        {
            var result = _carService.GetCarDetailByBrandName(brandName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcardetailbycolorname")]
        public IActionResult GetCarDetailByColorName(string colorName)
        {
            var result = _carService.GetCarDetailByColorName(colorName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcardetailbybrandnameandcolorname")]
        public IActionResult GetCarDetailByBrandNameAndColorName(string brandName,string colorName)
        {
            var result = _carService.GetCarDetailByBrandNameAndColorName(brandName, colorName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getdetail")]
        public IActionResult GetDetail(int carId)
        {
            var result = _carService.GetDetail(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
