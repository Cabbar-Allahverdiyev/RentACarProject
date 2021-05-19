using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail(Expression<Func<CarDetailDto,bool>> filter=null)
        {
            using (ReCapProjectContext context=new ReCapProjectContext())
            {
                var result = from c in context.Cars
                                join b in context.Brands on c.BrandId equals b.BrandId
                                join m in context.Models on c.ModelId equals m.ModelId
                                join color in context.Colors on c.ColorId equals color.ColorId
                                select new CarDetailDto 
                                { 
                                    CarId=c.CarId,
                                    BrandName=b.BrandName,
                                    ModelName=m.ModelName,
                                    ColorName=color.ColorName,
                                    ModelYear=c.ModelYear,
                                    DailyPrice=c.DailyPrice,
                                    CarDescription=c.CarDescription,
                                    BrandId=c.BrandId,
                                    ModelId=c.ModelId,
                                    ColorId=c.ColorId,
                                    ImagePath=(from  img in context.CarImages
                                               where img.CarId==c.CarId
                                               select img.ImagePath).FirstOrDefault()
                                };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
                              
            }

        }

        public CarDetailDto GetDetail(int carId)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from car in context.Cars.Where(c => c.CarId == carId)
                             join color in context.Colors
                               on car.ColorId equals color.ColorId

                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             select new CarDetailDto()
                             {
                                 BrandId = brand.BrandId,
                                 ColorId = color.ColorId,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 CarDescription = car.CarDescription,
                                 ModelYear = car.ModelYear,
                                 CarId = car.CarId,
                                 ImagePath = (from img in context.CarImages
                                              where img.CarId ==carId
                                              select img.ImagePath).FirstOrDefault()
                             };
                return result.SingleOrDefault();

            }
        }

       
       

      
    }


}
