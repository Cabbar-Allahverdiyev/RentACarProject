using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService : IEntityRepositoryService<Car>
    {
        List<Car> GetAll();
        void Add(Car entity);
        void Update(Car entity);
        void Delete(Car entity);
        List<Car> GetCarsByBrandId(int id);
        List<Car> GetCarsByColorId(int colorId);
        List<Car> GetbyDailyPrice(decimal min, decimal max);

        List<CarDetailDto> GetCarDetail();


    }
}
