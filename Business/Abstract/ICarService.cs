﻿using Entities.Concrete;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();

        List<Car> GetCarsByBrandId(int id);

        List<Car> GetCarByColorId(int id);

        void Add(Car car);
    }
}