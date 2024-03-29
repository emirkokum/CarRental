﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FulentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Data_Access.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        IUserDal _userDal;


        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.EntityAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.EntityDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.EntitiesListed);
        }

        public IDataResult<String> GetUserNameByMail(string email)
        {
            if (_userDal.Get(u => u.Email == email) != null)
            {
                User user = _userDal.Get(u => u.Email == email);
                string userName = user.FirstName + " " + user.LastName;
                return new SuccessDataResult<String>(data:userName,message:Messages.UserNameReturned);

            }
            return new ErrorDataResult<string>(Messages.ThereIsNoUserWithThisMail);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));
        }

        public IResult Update(User user)
        {
            if (user.Id > 0)
            {
                _userDal.Update(user);
                return new SuccessResult(Messages.EntityUpdated);
            }
            return new ErrorResult(Messages.EntityUpdateError);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}
