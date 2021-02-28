using Business.Concrete;
using Business.Constants;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());


            //Console.WriteLine("Avtomobilin  Id-sini daxil edin");
            //int carId = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Avtomobilin model Id-sini daxil edin");
            //int modelId = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Avtomobilin buraxildigi il");
            //int modelYear = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Avtomobilin gunluk qiymetini daxil edin");
            //decimal dailyPrice = Convert.ToDecimal(Console.ReadLine());

            //Console.WriteLine("Elave melumat");
            //string description = Console.ReadLine();

            //Console.WriteLine("Markanin Id-sini daxil edin");
            //int brandId = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Rengin Id-sini daxil edin");
            //int colorId = Convert.ToInt32(Console.ReadLine());


            //GetByClorIdTest(carManager);
            //ByBrandIdTest(carManager);
            //GetByDailyPriceTest(carManager);
            //UpdateTest();
            //DaxilEdilenler();
            //GetCarDetailsTest(carManager);
            //AddTest(carManager, carId, modelId, modelYear, dailyPrice, description, brandId, colorId);
            //GetAllTest(carManager);
            // GetCarsByBrandIdTest(carManager);
            //DeleteTest(carManager);


        }

        private static void GetByClorIdTest(CarManager carManager)
        {
            var result = carManager.GetCarsByColorId(3);
           
                foreach (var c in result.Data)
                {
                    Console.WriteLine(c.CarId + " " + c.CarDescription + " " + c.DailyPrice);
                }
            
           
           
        }

        private static void ByBrandIdTest(CarManager carManager)
        {
            var result = carManager.GetCarsByBrandId(2);
            foreach (var c in result.Data)
            {
                Console.WriteLine(c.CarId + " " + c.CarDescription + " " + c.DailyPrice);
            }
        }

        private static void GetByDailyPriceTest(CarManager carManager)
        {
            var result=carManager.GetbyDailyPrice(40,60);
            foreach (var c in result.Data)
            {
                Console.WriteLine(c.CarId + " " + c.CarDescription + " " + c.DailyPrice);
            }
        }

        private static void GetAllTest(CarManager carManager)
        {
            var result = carManager.GetAll();
            foreach (var c in result.Data)
            {
                Console.WriteLine(c.CarId + " " + c.CarDescription + " " + c.DailyPrice);
            }
        }

        private static void UpdateTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("Avtomobilin  Id-sini daxil edin");
            int carId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Avtomobilin model Id-sini daxil edin");
            int modelId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Avtomobilin buraxildigi il");
            int modelYear = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Avtomobilin gunluk qiymetini daxil edin");
            decimal dailyPrice = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Elave melumat");
            string description = Console.ReadLine();

            Console.WriteLine("Markanin Id-sini daxil edin");
            int brandId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Rengin Id-sini daxil edin");
            int colorId = Convert.ToInt32(Console.ReadLine());

            carManager.Update(new Car
            {
                CarId = carId,
                BrandId = brandId,
                ModelId = modelId,
                ColorId = colorId,
                DailyPrice = dailyPrice,
                CarDescription = description,
                ModelYear = modelYear
            });
        }

        private static void DeleteTest(CarManager carManager)
        {
            carManager.Delete(new Car { CarId = 9 });
            Console.WriteLine(Messages.CarDeleted);
        }

        private static void GetCarsByBrandIdTest(CarManager carManager)
        {
            var result = carManager.GetCarsByBrandId(2);
            foreach (var c in result.Data)
            {
                Console.WriteLine(c.CarId + " " + c.CarDescription + " " + c.DailyPrice);
            }
        }



        private static void GetCarDetailsTest(CarManager carManager)
        {
            var result = carManager.GetCarDetail();
            foreach (var c in result.Data)
            {
                Console.WriteLine(c.CarId + " " + c.ModelName + " " + c.BrandName);
            }
        }

        //private static void DaxilEdilenler()
        //{
        //    Console.WriteLine("Avtomobilin  Id-sini daxil edin");
        //    int carId = Convert.ToInt32(Console.ReadLine());

        //    Console.WriteLine("Avtomobilin model Id-sini daxil edin");
        //    int modelId = Convert.ToInt32(Console.ReadLine());

        //    Console.WriteLine("Avtomobilin buraxildigi il");
        //    int modelYear =Convert.ToInt32( Console.ReadLine());

        //    Console.WriteLine("Avtomobilin gunluk qiymetini daxil edin");
        //    decimal dailyPrice = Convert.ToDecimal(Console.ReadLine());

        //    Console.WriteLine("Elave melumat");
        //    string description = Console.ReadLine();

        //    Console.WriteLine("Markanin Id-sini daxil edin");
        //    int brandId = Convert.ToInt32(Console.ReadLine());

        //    Console.WriteLine("Rengin Id-sini daxil edin");
        //    int colorId = Convert.ToInt32(Console.ReadLine());
        //}

        private static void AddTest(CarManager carManager, int carId,
            int modelId, int modelYear, decimal dailyPrice, string description, int brandId, int colorId)
        {
            carManager.Add(new Car
            {
                CarId = carId,
                BrandId = brandId,
                ModelId = modelId,
                ColorId = colorId,
                DailyPrice = dailyPrice,
                CarDescription = description,
                ModelYear = modelYear
            });
        }
    }
}
