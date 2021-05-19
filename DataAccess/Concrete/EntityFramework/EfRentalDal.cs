using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars on rental.CarId equals car.CarId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join model in context.Models on brand.BrandId equals model.BrandId
                             join customer in context.Customers on rental.CustomerId equals customer.CustomerId
                             join user in context.Users on customer.UserId equals user.Id
                             select new RentalDetailDto
                             {
                                 RentalId = rental.RentalId,
                                 BrandName = brand.BrandName,
                                 ModelName = model.ModelName,
                                 CustomerName = $"{user.FirstName} {user.LastName}",
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
