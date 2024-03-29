﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 500, ModelYear = "2016" ,CarName = "17000 km"},
                new Car{Id = 2, BrandId = 2, ColorId = 2, DailyPrice = 1500, ModelYear = "2022" ,CarName = "6000 km"},
                new Car{Id = 3, BrandId = 2, ColorId = 2, DailyPrice = 700, ModelYear = "2015" ,CarName = "24000 km"},
                new Car{Id = 4, BrandId = 1, ColorId = 2, DailyPrice = 300, ModelYear = "2012" ,CarName = "18000 km"},
                new Car{Id = 5, BrandId = 1, ColorId = 1, DailyPrice = 900, ModelYear = "2017" ,CarName = "45000 km"}
            };
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public void Update(Car car)
        {

            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;  
            carToUpdate.CarName = car.CarName;

        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsByColorId(int colorId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsById(int carId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsByBrandAndColorId(int brandId, int colorId)
        {
            throw new NotImplementedException();
        }
    }
}
