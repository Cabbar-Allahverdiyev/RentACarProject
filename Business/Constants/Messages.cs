using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //Cars
        public static string CarAdded = "Avtomobil elave edildi";
        public static string CarsListed = "Avtomobiller siyahiya alindi";
        public static string CarsNotListed = "Avtomobiller siyahiya alina bilmedi";
        public static string CarsByDailyPrice = "Avtomobiller gunluk qiymete gore siralandi";
        public static string CarsByNotDailyPrice = "Avtomobiller gunluk qiymete gore siralana bilmedi";
        public static string CarDetailsListed = "Avtomobiller elave melumatlara gore siralandi";
        public static string CarNotDetailsListed = "Avtomobiller elave melumatlara gore siralana bilmedi";
        public static string CarDeleted = "Avtomobil silindi";
        public static string CarNotDeleted = "Avtomobil siline bilmedi.Avtomobilin aciqlamasi en az 2 isareden boyuk olmalidir";
        public static string CarUptaded = "Avtomobil melumatlari yenilendi";
        public static string CarNotUptaded = "Avtomobilin melumatlari yenilene bilmedi.Avtomobilin aciqlamasi en az 2 isareden boyuk olmalidir";
        public static string CarDesInvalidUnitInvalid = "Aciqlama bolumunu 2 isareden boyuk olmalidir ve gunluk qiymet 0 dan ferqli olmalidir";
        public static string CarDesInvalid = "Aciqlama bolumunu 2 isareden boyuk olmalidir.";
        public static string CarUnitPriceInvalid = "Gunluk qiymet 0 dan boyuk olmalidir";
        public static string CarByBrandId="Avtomobilleri markaya gore siralandi";
        public static string CarByNotBrandId="Avtomobilleri markaya gore siralana bilmedi";
        public static string CarByColorId = "Avtomobilleri renge gore siralandi";
        public static string CarByNotColorId = "Avtomobilleri renge gore siralana bilmedi";
        public static string CarById = "Avtomobil tapildi";
        public static string CarByNotId = "Avtomobil tapila bilmedi";


        //Brands
        public static string BrandAdded = "Marka elave edildi";
        public static string BrandNameInvalid = "Marka  adi uygun deyil";
        public static string BrandsListed = "Markalar siyahiya alindi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandNotDeleted = "Marka siline bilmedi";
        public static string BrandUpdated = "Marka  yenilendi";
        public static string BrandNotUptaded = "Marka yenilene bilmedi";

        //Models
        public static string ModelAdded = "Model elave edildi";
        public static string ModelNameInvalid = "Model adi uygun deyil";
        public static string ModelsListed = "Modeller siyahiya alindi";
        public static string ModelDeleted = "Model silindi";
        public static string ModelNotDeleted = "Model siline bilmedi";
        public static string ModelUpdated = "Model  yenilendi";
        public static string ModelNotUptaded = "Model yenilene bilmedi";

        //Colors
        public static string ColorsListed = "Rengler siyahiya alindi";
        public static string ColorAdded = "Avtomobil elave edildi";
        public static string ColorNameInvalid = "Model adi uygun deyil";
        public static string ColorDeleted = "Reng silindi";
        public static string ColorNotDeleted = "Reng siline bilmedi";
        public static string ColorUpdated = "Reng  yenilendi";
        public static string ColorNotUptaded = "Reng yenilene bilmedi";

        //Customer
        public static string CustomerAdded= "Mustəri əlavə edildi";
        public static string CustomerDeleted = "Mustəri silindi";
        public static string CustomerUpdated = "Mustəri yeniləndi";
        public static string CustomerGetAll= "Mustərilər siralandi";

        //User
        public static string UserAdded = "Istifadəci əlavə edildi";
        public static string UserDeleted = "Istifadəci silindi";
        public static string UserUpdated = "Isifadəci yeniləndi";
        public static string UserGetAll = "Isifadəcilər siralandi";

        //Rental
        public static string RentalAdded = "Avtomobil icarəyə goturuldu";
        public static string RentalNotAdded = "Avtomobil icarəyə goturulə bilmədi";
        public static string RentalDeleted = "Avtomobil icarəsi legv edildi";
        public static string RentalUpdated = "Avtomobil icarəsi yenilendi";
        public static string RentalGetAll = "Avtomobil icarələri siralandi";

        //Elave
        public static string MaintenanceTime = "Sistem temirdedir xahis edirik saat 23:00 dan sonra";
        
    }
}
//
