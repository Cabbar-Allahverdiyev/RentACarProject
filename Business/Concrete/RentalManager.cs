using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentaldal)
        {
            _rentalDal = rentaldal;
        }

        [CacheRemoveAspect("IRentalService.Get")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {

            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate == null);

            if (result.Count > 0)
            {
                return new ErrorResult(Messages.RentalNotAdded);
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);


        }


        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {

            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }


        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalGetAll);
        }

        [CacheAspect]
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == id));
        }

        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetail(), Messages.GetRentalDetailListed);
        }


        [CacheRemoveAspect("IRentalService.Get")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {

            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
