using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorService _colorService;
        public void Add(Color color)
        {
            _colorService.Add(color);
        }

        public void Delete(Color color)
        {
            _colorService.Delete(color);

        }

        public List<Color> GetAll()
        {
            return _colorService.GetAll();
        }

        public void Update(Color color)
        {
            _colorService.Update(color);

        }
    }
}
