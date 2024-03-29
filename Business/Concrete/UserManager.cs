﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.UserGetAll);
        }

        public IDataResult<User> GetByMail(string email)
        {
            User get = _userDal.Get(u => u.Email == email);
            if (get == null)
                return new ErrorDataResult<User>();
            return new  SuccessDataResult<User>( get);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var get = _userDal.GetClaims(user);
            if (get==null)
            {
                return new ErrorDataResult<List<OperationClaim>>(Messages.GetClaimsIsNull);
            }
            return new SuccessDataResult<List<OperationClaim>>(get);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
