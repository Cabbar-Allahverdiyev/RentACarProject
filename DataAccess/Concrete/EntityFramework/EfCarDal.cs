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
        public List<CarDetailDto> GetCarDetail()
        {
            using (ReCapProjectContext context=new ReCapProjectContext())
            {
                var result = from c in context.Cars
                                join b in context.Brands on c.BrandId equals b.BrandId
                                join m in context.Models on b.BrandId equals m.BrandId
                                join color in context.Colors on c.ColorId equals color.ColorId
                                select new CarDetailDto 
                                { 
                                    CarId=c.CarId,
                                    BrandName=b.BrandName,
                                    ModelName=m.ModelName,
                                    ColorName=color.ColorName,
                                    DailyPrice=c.DailyPrice
                                };
                return result.ToList();
                              
            }

        }

        //public List<CarDetailDto> GetCarsByBrandId(int brandId)
        //{
        //    using (ReCapProjectContext context = new ReCapProjectContext())
        //    {

        //        var result = from c in context.Cars
        //                     join b in context.Brands on c.BrandId equals b.BrandId
        //                     join m in context.Models on b.BrandId equals m.BrandId
        //                     where (c.BrandId == brandId)
        //                     orderby c.DailyPrice descending
        //                     select new CarDetailDto 
        //                     { 
        //                         BrandName = b.BrandName,
        //                         CarId = c.CarId, 
        //                         ModelName = m.ModelName,
        //                         DailyPrice = c.DailyPrice 
        //                     };



        //        return result.ToList();
        //    }
        //}

        //public List<CarDetailDto> GetCarsByColorId(int colorId)
        //{
        //    using (ReCapProjectContext context = new ReCapProjectContext())
        //    {
        //        var result = from c in context.Cars
        //                     join m in context.Models on c.BrandId equals m.BrandId
        //                     join b in context.Brands on m.BrandId equals b.BrandId
        //                     join color in context.Colors on c.ColorId equals color.ColorId
        //                     where (color.ColorId == colorId)
        //                     select new CarDetailDto { BrandName = b.BrandName, CarId = c.CarId, ModelName = m.ModelName, DailyPrice = c.DailyPrice, ColorName = color.ColorName };
        //        return result.ToList();
        //    }
        //}

       

      
    }


}
