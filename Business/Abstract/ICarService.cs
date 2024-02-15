using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        void Add(Car car);

        List<Car> GetAll();

        Car GetById(int id);

        void Update(Car car);

        void Delete(int id);

        List<Car> GetCarsByBrandId(int id);

        List<Car> GetCarByColorId(int id);

        List<CarDetailDto> GetCarDetails();

    }
}
