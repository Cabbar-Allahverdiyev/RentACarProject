using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string CarDescription { get; set; }
        public string ImagePath { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public int ColorId { get; set; }
    }
}
