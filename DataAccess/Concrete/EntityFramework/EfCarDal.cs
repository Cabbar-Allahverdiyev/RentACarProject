using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (ReCapProjectContext context=new ReCapProjectContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (ReCapProjectContext context=new ReCapProjectContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapProjectContext context=new ReCapProjectContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProjectContext context=new ReCapProjectContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void GetCarsByBrandId(int brandId)
        {
            using (ReCapProjectContext context=new ReCapProjectContext())
            {

                var result  = from c in context.Cars
                                            join b in context.Brands on c.BrandId equals b.BrandId
                                            join m in context.Models on b.BrandId equals m.BrandId
                                            where (c.BrandId == brandId) 
                                            orderby c.DailyPrice descending 
                                            select new CarsDto { BrandName=b.BrandName,CarId=c.CarId,ModelName=m.ModelName,DailyPrice=c.DailyPrice} ;
               
                                          
                                          
                foreach (var c in result)
                {
                    Console.WriteLine(c.CarId+" "+c.BrandName+" "+c.ModelName+" "+c.DailyPrice);
                }
            }
        }

        public void Update(Car entity)
        {
            using (ReCapProjectContext context=new ReCapProjectContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
    public class CarsDto
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
