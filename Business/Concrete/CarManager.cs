using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using DataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car entity)
        {
            if ((entity.CarDescription).Length>2 && entity.DailyPrice>0)
            {
                _carDal.Add(entity);
            }
            else
            {
                if ((entity.CarDescription).Length<=2 && entity.DailyPrice<=0)
                {
                    Console.WriteLine("Aciqlama bolumunu 2 isareden boyuk olmalidir ve gunluk qiymet 0 dan ferqli olmalidir");
                }
                else
                {
                    if ((entity.CarDescription).Length<=2)
                    {
                        Console.WriteLine("Aciqlama bolumunu 2 isareden boyuk olmalidir");
                    }
                    else
                    {
                        Console.WriteLine("Gunluk qiymet 0 dan boyuk olmalidir");
                    }
                }
            }
        }

        public void Delete(Car entity)
        {
            _carDal.Delete(entity);
        }

       

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetbyDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }

        public List<CarDetailDto> GetCarDetail()
        {
           return _carDal.GetCarDetail();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public void Update(Car entity)
        {
             _carDal.Update(entity);
        }
    }
}
