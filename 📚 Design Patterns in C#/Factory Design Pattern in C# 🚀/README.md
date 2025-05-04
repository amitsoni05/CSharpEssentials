
# 🎨 Factory Design Pattern in C# 🚀



## 📌 Importance of the Factory Design Pattern

The Factory Design Pattern is a **creational design pattern** that handles object creation in a specific way. This pattern helps you hide the object creation process from the client, making the code more straightforward and flexible. 💡

## 🔍 Real-Life Example

To understand the **Factory Design Pattern**, consider a real-life example:

Imagine you have a warehouse storing different types of fabric, such as dress shirts and coats. This warehouse has the fabric, and a factory converts these fabrics into dress shirts and coats.

1. **Warehouse**: Stores the fabric. 🏭
2. **Factory**: Converts the fabric into shirts or coats. 🧵
3. **Operation Manager**: Takes orders in the factory and prepares shirts or coats. 👔

## 🛠️ Implementation of the Factory Design Pattern

### First Step

1. **Create the Interface**:
   ```csharp
   public interface IVehicle
   {
       string VehicleType();
       int NumberOfWheels();
   }
   ```

2. **Implement the Interface**:
   ```csharp
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
   ```

### Second Step

1. **Create the Factory Class**:
   ```csharp
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
   ```

2. **Use the Factory**:
   ```csharp
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
   ```

## ✅ Conclusion

The Factory Design Pattern makes your code more flexible and manageable. It allows you to hide object creation from the client, making your code easier to extend and maintain. 🌟

If you enjoyed this video, please **subscribe** to my channel and click the **bell icon** to receive notifications about new videos. Thank you! 🙏

---

Feel free to adjust or customize the content as needed!