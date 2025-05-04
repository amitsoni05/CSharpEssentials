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
