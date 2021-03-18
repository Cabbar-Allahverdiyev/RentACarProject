using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using DataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using Entities.DTOs;
using Core.Utilities;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.BusinessRules;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService;
        public CarManager(ICarDal carDal,IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;

        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car entity)
        {
            IResult result = BusinessRules.Run();

            if (result!=null)
            {
                return result;
            }

            _carDal.Add(entity);
            return new SuccessResult(Messages.CarAdded);
        }


        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            throw new NotImplementedException();
        }


        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car entity)
        {

            _carDal.Delete(entity);
            return new SuccessResult(Messages.CarDeleted);
        }


        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max), Messages.CarsByDailyPrice);
        }


        [CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {

            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId), Messages.CarById);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail(), Messages.CarDetailsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {


            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id), Messages.CarByBrandId);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), Messages.CarByColorId);
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car entity)
        {

            _carDal.Update(entity);
            return new SuccessResult(Messages.CarUptaded);
        }
    }
}
