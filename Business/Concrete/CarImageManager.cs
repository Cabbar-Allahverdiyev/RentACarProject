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
using Core.Aspects.Autofac.Caching;
using System.IO;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [CacheRemoveAspect("ICarImageService.Get")]
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

        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }


        [CacheAspect]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }


        [CacheAspect]
        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c=>c.CarId==id));
        }

        [CacheAspect]
        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c=>c.ImageId==id));
        }

        [CacheRemoveAspect("ICarImageService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitExceed(carImage.CarId));
            if (result!=null)
            {
                return new ErrorResult(result.Message);
            }

            var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\Wwwroot"))+_carImageDal.Get(p=>p.ImageId==carImage.ImageId).ImagePath;

            carImage.ImagePath = FileHelper.Update(oldPath,file);
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

        private IDataResult<List<CarImage>> CheckIfImageNull(int id)
        {
            try
            {
                string path = @"\Images\Default.jpg";
                var result = _carImageDal.GetAll(c=>c.CarId==id).Any();
                if (!result)
                {
                    List<CarImage> carImages = new List<CarImage>();
                    carImages.Add(new CarImage { CarId=id,ImagePath=path,Date=DateTime.Now});
                    return new SuccessDataResult<List<CarImage>>(carImages);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id).ToList()) ;
        }
    }
}
