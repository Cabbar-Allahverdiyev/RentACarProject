using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.BusinessRules;
using Core.Utilities.Helpers;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitExceed(carImage.CarId));
            if (result!=null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        
        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c=>c.CarId==id));
        }


        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c=>c.ImageId==id));
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(c=>c.ImageId==carImage.ImageId).ImagePath,file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new  SuccessResult();
        }

        //Bu class ucun Methodlar
        private IResult CheckIfCarImageLimitExceed(int carId)
        {
            var carImage = _carImageDal.GetAll(c => c.CarId == carId);
            if (carImage.Count>=5)
            {
                return new ErrorResult(Messages.CarImageLimitExceed);
            }
            return new SuccessResult();
        }
    }
}
