﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        IColorDal _colorDal;

        [SecuredOperation("admin")]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.EntityAdded);
        }

        [SecuredOperation("admin,seller")]
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.EntityDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.EntitiesListed);
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == id));
        }

        public IResult Update(Color color)
        {
            if (color.Id > 0)
            {
                _colorDal.Update(color);
                return new SuccessResult(Messages.EntityUpdated);
            }
            return new ErrorResult(Messages.EntityUpdateError);
        }
    }
}
