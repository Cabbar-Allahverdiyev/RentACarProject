using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.GetCarsByBrandId(2);
            //foreach (var c in carManager.GetAll())
            //{
            //    Console.WriteLine(c.CarDescription);
            //}

        }
    }
}
