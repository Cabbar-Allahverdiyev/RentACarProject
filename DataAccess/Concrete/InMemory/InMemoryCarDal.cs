﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal //: ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=0000,ModelYear=2016,DailyPrice=65,CarDescription="Gozel avtomobildir"},
                new Car{CarId=2,BrandId=1,ColorId=1010,ModelYear=2019,DailyPrice=95,CarDescription="Gozel ve yeni avtomobildir"},
                new Car{CarId=3,BrandId=2,ColorId=1000,ModelYear=2013,DailyPrice=43,CarDescription="Serfeli,rahat avtomobildir"},
                new Car{CarId=4,BrandId=3,ColorId=0000,ModelYear=2018,DailyPrice=57,CarDescription="Serfeli ve dozumlu avtomobildir"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
            
        }

        public void Delete(Car car)
        {
            Car CarToDelete = _cars.SingleOrDefault(c=>c.CarId==car.CarId);
            _cars.Remove(CarToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(c=>c.BrandId==brandId).ToList();
        }

        public List<CarDetailDto> GetCarDetail(Expression<Func<CarDetailDto,bool>> filter=null)
        {
            throw new NotImplementedException();
        }

        public void GetCarsByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public void GetCarsByColorId(int colorId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c=>c.CarId==car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.CarDescription = car.CarDescription;
        }
    }
}
