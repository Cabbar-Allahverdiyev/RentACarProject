using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService : IEntityRepositoryService<Color>
    {
        List<Color> GetAll();
        void Add(Color color);
        void Update(Color color);
        void Delete(Color color);
    }
}
