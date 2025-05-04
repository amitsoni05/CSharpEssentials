using System;

public interface IVehicle
{
    string VehicleType();
    int NumberOfWheels();
}

public class Bike : IVehicle
{
    public string VehicleType() => "Bike";
    public int NumberOfWheels() => 2;
}

public class Car : IVehicle
{
    public string VehicleType() => "Car";
    public int NumberOfWheels() => 4;
}

public class VehicleFactory
{
    public static IVehicle GetVehicle(string vehicleType)
    {
        if (vehicleType == "Bike")
        {
            return new Bike();
        }
        else if (vehicleType == "Car")
        {
            return new Car();
        }
        else
        {
            throw new ArgumentException("Invalid vehicle type");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        IVehicle bike = VehicleFactory.GetVehicle("Bike");
        Console.WriteLine($"Vehicle Type: {bike.VehicleType()}, Number of Wheels: {bike.NumberOfWheels()}");

        IVehicle car = VehicleFactory.GetVehicle("Car");
        Console.WriteLine($"Vehicle Type: {car.VehicleType()}, Number of Wheels: {car.NumberOfWheels()}");
    }
}
