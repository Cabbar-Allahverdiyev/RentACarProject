using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class ModelManager : IModelService
    {
        IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        [ValidationAspect(typeof(ModelValidator))]
        public IResult Add(Model model)
        {
          
            _modelDal.Add(model);

            return new SuccessResult(Messages.ModelAdded);
        }

        public IResult Delete(Model model)
        {
            
            _modelDal.Delete(model);

            return new SuccessResult(Messages.ModelDeleted);
        }

        public IDataResult<List<Model>> GetAll()
        {
            
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll(), Messages.BrandsListed);

        }


        public IResult Update(Model model)
        {
            
            _modelDal.Update(model);
            return new SuccessResult(Messages.ModelUpdated);
        }
    }
}
