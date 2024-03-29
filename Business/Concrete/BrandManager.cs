﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FulentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        IBrandDal _brandDal;

       
        [ValidationAspect(typeof(BrandValidator))]
        [SecuredOperation("admin,brand.add")]
        //[CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.EntityAdded);
        }

        [SecuredOperation("admin")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.EntityDeleted);
        }


        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.EntitiesListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == id));
        }


        [CacheRemoveAspect("IBrandService.Update")]
        public IResult Update(Brand brand)
        {
            if (brand.Id > 0)
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.EntityUpdated);
            }
            return new ErrorResult(Messages.EntityUpdateError);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Brand brand)
        {
            Add(brand);
            if (brand.Id < 5)
            {
                throw new Exception("");
            }

            Add(brand);

            return null;
        }
    }
}
