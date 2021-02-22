using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext> :IEntityRepository<TEntity>
        where TEntity:class, IEntity, new()
        where  TContext:DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

       

        //public void GetCarsByBrandId(int brandId)
        //{
        //    using (TContext context = new TContext())
        //    {

        //        var result = from c in context.Cars
        //                     join b in context.Brands on c.BrandId equals b.BrandId
        //                     join m in context.Models on b.BrandId equals m.BrandId
        //                     where (c.BrandId == brandId)
        //                     orderby c.DailyPrice descending
        //                     select new CarsDto { BrandName = b.BrandName, CarId = c.CarId, ModelName = m.ModelName, DailyPrice = c.DailyPrice };



        //        foreach (var c in result)
        //        {
        //            Console.WriteLine(c.CarId + " " + c.BrandName + " " + c.ModelName + " " + c.DailyPrice);
        //        }
        //    }
        //}

        ////public void GetCarsByColorId(int colorId)
        ////{
        ////    using (TContext context = new TContext())
        ////    {
        ////        var result = from c in context.Cars
        ////                     join m in context.Models on c.BrandId equals m.BrandId
        ////                     join b in context.Brands on m.BrandId equals b.BrandId
        ////                     join color in context.Colors on c.ColorId equals color.ColorId
        ////                     where (color.ColorId == colorId)
        ////                     select new CarsDto { BrandName = b.BrandName, CarId = c.CarId, ModelName = m.ModelName, DailyPrice = c.DailyPrice, ColorName = color.ColorName };
        ////        foreach (var c in result)
        ////        {
        ////            Console.WriteLine(c.CarId + " " + c.BrandName + " " + c.ModelName + " " + c.DailyPrice);
        ////        }
        ////    }
        ////}

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
