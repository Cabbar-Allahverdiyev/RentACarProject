using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IModelService : IEntityRepositoryService<Model>
    {
        List<Model> GetAll();
        void Add(Color color);
        void Update(Color color);
        void Delete(Color color);
    }
}
