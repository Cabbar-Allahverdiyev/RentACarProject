﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [CacheRemoveAspect("IColorService.Get")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            
            _colorDal.Add(color);

            return new SuccessResult(Messages.ColorAdded);
        }


        [CacheRemoveAspect("IColorService.Get")]
        public IResult Delete(Color color)
        {
           
            _colorDal.Delete(color);

            return new SuccessResult(Messages.ColorDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Color>> GetAll()
        {
            
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorsListed);

        }

        [CacheRemoveAspect("IColorService.Get")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            
            _colorDal.Update(color);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
