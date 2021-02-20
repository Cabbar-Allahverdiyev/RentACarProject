using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using DataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

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

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            return _carDal.Get(filter);
        }

        

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _carDal.GetAll();
        }

        public void GetCarsByBrandId(int brandId)
        {
            _carDal.GetCarsByBrandId(brandId);
        }
    }
}
