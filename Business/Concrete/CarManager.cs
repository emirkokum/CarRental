using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.CarDescription.Length < 5)
            {
                return new ErrorResult(Messages.InvalidCarName);
            }

            _carDal.Add(car);
            return new  SuccessResult(Messages.EntityAdded);
        }

        public IResult Delete(int id)
        {
            _carDal.Delete(_carDal.Get(c => c.Id == id));
            return new SuccessResult(Messages.EntityDeleted);
        }

        public IResult Update(Car car)
        {
            if (car.Id > 0)
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.EntityUpdated);
            }
            return new ErrorResult(Messages.EntityUpdateError);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);    
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll()); 
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id)) ;
        }

        public IDataResult<List<Car>>GetCarByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id)) ;
        }
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.EntityDetailsListed) ;
        }



    }
}
