using System;

// Step 1: Define the abstract products
public interface ICar
{
    void ManufactureCar();
}

public interface IBike
{
    void ManufactureBike();
}

// Step 2: Implement concrete products
public class HondaCar : ICar
{
    public void ManufactureCar()
    {
        Console.WriteLine("Honda Car manufactured.");
    }
}

public class SuzukiBike : IBike
{
    public void ManufactureBike()
    {
        Console.WriteLine("Suzuki Bike manufactured.");
    }
}

public class ToyotaCar : ICar
{
    public void ManufactureCar()
    {
        Console.WriteLine("Toyota Car manufactured.");
    }
}

public class YamahaBike : IBike
{
    public void ManufactureBike()
    {
        Console.WriteLine("Yamaha Bike manufactured.");
    }
}

// Step 3: Define the abstract factory
public interface IVehicleFactory
{
    ICar GetCar();
    IBike GetBike();
}

// Step 4: Implement concrete factories
public class HondaFactory : IVehicleFactory
{
    public ICar GetCar()
    {
        return new HondaCar();
    }

    public IBike GetBike()
    {
        return new SuzukiBike();
    }
}

public class ToyotaFactory : IVehicleFactory
{
    public ICar GetCar()
    {
        return new ToyotaCar();
    }

    public IBike GetBike()
    {
        return new YamahaBike();
    }
}

// Step 5: Use the factory in the client code
class Client
{
    private ICar _car;
    private IBike _bike;

    public Client(IVehicleFactory factory)
    {
        _car = factory.GetCar();
        _bike = factory.GetBike();
    }

    public void ManufactureVehicles()
    {
        _car.ManufactureCar();
        _bike.ManufactureBike();
    }
}

// Test the pattern
class Program
{
    static void Main(string[] args)
    {
        // Using HondaFactory
        IVehicleFactory hondaFactory = new HondaFactory();
        Client hondaClient = new Client(hondaFactory);
        hondaClient.ManufactureVehicles();

        Console.WriteLine();

        // Using ToyotaFactory
        IVehicleFactory toyotaFactory = new ToyotaFactory();
        Client toyotaClient = new Client(toyotaFactory);
        toyotaClient.ManufactureVehicles();
    }
}
