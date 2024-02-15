using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

internal class Program
{
    public static void Main(string[] args)
    {
        ICarService carManager = new CarManager(new EfCarDal());
        //AddDeleteTest(carManager);
        //GetCarDetailsTest(carManager);
    
        GetCarDetailsTest(carManager);
    
    }


    private static void GetCarDetailsTest(ICarService carManager)
    {
        foreach (var car in carManager.GetCarDetails())
        {
            Console.WriteLine(car.CarName + " | " + car.ColorName + " | " + car.BrandName + " | " + car.DailyPrice);

        }
    }

    private static void AddDeleteTest(ICarService carManager)
    {
        carManager.Add(new Car { Id = 6, BrandId = 2, ColorId = 2, DailyPrice = 500, ModelYear = "2018", CarDescription = "Wolkswagen passat" });
        GetCarsTest(carManager);
        Console.WriteLine("----------------");
        carManager.Delete(6);
        GetCarsTest(carManager);
    }

    private static void GetCarsTest(ICarService carManager)
    {
        int i = 1;
        foreach (var car in carManager.GetAll())
        {
            Console.WriteLine($"CAR {i}");
            Console.WriteLine(car.Id);
            Console.WriteLine(car.ModelYear);
            Console.WriteLine(car.CarDescription);
            Console.WriteLine("----------");
            i++;
        }
    }
}