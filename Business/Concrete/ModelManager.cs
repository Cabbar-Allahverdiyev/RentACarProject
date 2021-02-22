using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class ModelManager : IModelService
    {
        IModelService _modelService;
        public void Add(Color color)
        {
            _modelService.Add(color);
        }

        public void Delete(Color color)
        {
            _modelService.Delete(color);

        }

        public List<Model> GetAll()
        {
            return _modelService.GetAll();
        }

        public void Update(Color color)
        {
            _modelService.Update(color);
        }
    }
}
