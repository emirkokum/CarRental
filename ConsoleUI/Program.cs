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

        //GetCars(carManager);

        carManager.GetAll();


    }

    private static void GetCars(ICarService carManager)
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