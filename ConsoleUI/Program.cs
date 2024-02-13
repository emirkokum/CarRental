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

        //Car car5 = new Car() { Id=5,BrandId=5,ColorId=3,DailyPrice= -20,CarDescription="a",ModelYear="2015"};
        //carManager.Add(car5);


    }
}