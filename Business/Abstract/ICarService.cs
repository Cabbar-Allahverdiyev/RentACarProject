using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService 
    {
        IDataResult<List<Car>> GetAll();
        IResult Add(Car entity);
        IResult Update(Car entity);
        IResult Delete(Car entity);
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);
        IDataResult<Car> GetById(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetail();
        IDataResult<List<CarDetailDto>> GetCarDetailByBrandName(string brandName);
        IDataResult<List<CarDetailDto>> GetCarDetailByColorName(string colorName);
        IDataResult<List<CarDetailDto>> GetCarDetailByBrandNameAndColorName(string brandName,string colorName);
        IDataResult<CarDetailDto> GetDetail(int carId);

        IResult AddTransactionalTest(Car car);


    }
}
