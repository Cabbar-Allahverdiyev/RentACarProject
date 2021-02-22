using Business.Concrete;
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
            foreach (var c in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine(c.CarId + " " + c.CarDescription + " " + c.DailyPrice);
            }
        }

        private static void ByBrandIdTest(CarManager carManager)
        {
            foreach (var c in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(c.CarId + " " + c.CarDescription + " " + c.DailyPrice);
            }
        }

        private static void GetByDailyPriceTest(CarManager carManager)
        {
            foreach (var c in carManager.GetbyDailyPrice(40, 60))
            {
                Console.WriteLine(c.CarId + " " + c.CarDescription + " " + c.DailyPrice);
            }
        }

        private static void GetAllTest(CarManager carManager)
        {
            foreach (var c in carManager.GetAll())
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
            int modelYear =Convert.ToInt32( Console.ReadLine());

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
            carManager.Delete(new Car { CarId = 10 });
        }

        private static void GetCarsByBrandIdTest(CarManager carManager)
        {
            foreach (var c in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(c.CarId + " " + c.CarDescription + " " + c.DailyPrice);
            }
        }

      

        private static void GetCarDetailsTest(CarManager carManager)
        {
            foreach (var c in carManager.GetCarDetail())
            {
                Console.WriteLine(c.CarId + " " + c.ModelName + " " + c.BrandName);
            }
        }

        private static void DaxilEdilenler()
        {
            Console.WriteLine("Avtomobilin  Id-sini daxil edin");
            int carId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Avtomobilin model Id-sini daxil edin");
            int modelId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Avtomobilin buraxildigi il");
            int modelYear =Convert.ToInt32( Console.ReadLine());

            Console.WriteLine("Avtomobilin gunluk qiymetini daxil edin");
            decimal dailyPrice = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Elave melumat");
            string description = Console.ReadLine();

            Console.WriteLine("Markanin Id-sini daxil edin");
            int brandId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Rengin Id-sini daxil edin");
            int colorId = Convert.ToInt32(Console.ReadLine());
        }

        private static void AddTest(CarManager carManager, int carId, int modelId, int modelYear, decimal dailyPrice, string description, int brandId, int colorId)
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
