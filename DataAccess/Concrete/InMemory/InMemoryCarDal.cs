using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=0000,ModelYear=2016,DailyPrice=65,Description="Gozel avtomobildir"},
                new Car{Id=2,BrandId=1,ColorId=1010,ModelYear=2019,DailyPrice=95,Description="Gozel ve yeni avtomobildir"},
                new Car{Id=3,BrandId=2,ColorId=1000,ModelYear=2013,DailyPrice=43,Description="Serfeli,rahat avtomobildir"},
                new Car{Id=4,BrandId=3,ColorId=0000,ModelYear=2018,DailyPrice=57,Description="Serfeli ve dozumlu avtomobildir"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
            
        }

        public void Delete(Car car)
        {
            Car CarToDelete = _cars.SingleOrDefault(c=>c.Id==car.Id);
            _cars.Remove(CarToDelete);
        }

 

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(c=>c.BrandId==brandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c=>c.Id==car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
