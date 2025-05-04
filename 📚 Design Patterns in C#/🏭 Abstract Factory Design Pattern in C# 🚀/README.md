
# 🏭 Abstract Factory Design Pattern in C# 🚀

Welcome to the lecture on the **Abstract Factory Design Pattern** in C#! In this lecture, we will dive into the concept of Abstract Factory, how it enhances the Factory Design Pattern, and its practical applications with diagrams and examples. 📚

## 📚 Overview

The Abstract Factory Design Pattern is a **creational pattern** that provides an interface to create families of related or dependent objects without specifying their concrete classes. It is particularly useful when a system needs to be independent of how its products are created, composed, and represented.

## 📖 Key Points

1. **Definition**:
   - The Abstract Factory Design Pattern provides an interface to create product families. It hides the implementation details and abstracts the creation process, making it easier to manage multiple product variations.

2. **When to Use**:
   - Useful when a system needs to be independent of how its products are created and presented. It is ideal for situations where products need to be compatible with each other and follow a common interface.

3. **Components**:
   - **Abstract Factory**: Defines an interface for creating abstract products.
   - **Concrete Factory**: Implements the creation methods for concrete products.
   - **Abstract Product**: Declares an interface for a type of product.
   - **Concrete Product**: Implements the Abstract Product interface.
   - **Client**: Uses the Abstract Factory and Abstract Products.

4. **Example**:
   - **Phase 1**: Creation of abstract factories for Cars and Bikes.
   - **Phase 2**: Creation of a super factory (VehicleCompany) that produces Cars and Bikes using specific factories.

## 🛠️ Practical Implementation

Certainly! Here’s a simple example of how you might implement the Abstract Factory Design Pattern in C#. This example revolves around creating cars and bikes using abstract factories.

```csharp
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
```

### Explanation:

1. **Abstract Products**:
   - `ICar` and `IBike` are interfaces that define the methods `ManufactureCar` and `ManufactureBike`.
   
2. **Concrete Products**:
   - `HondaCar`, `SuzukiBike`, `ToyotaCar`, and `YamahaBike` are concrete implementations of `ICar` and `IBike`.

3. **Abstract Factory**:
   - `IVehicleFactory` is an interface that defines methods to get instances of `ICar` and `IBike`.

4. **Concrete Factories**:
   - `HondaFactory` and `ToyotaFactory` implement `IVehicleFactory` to produce instances of specific cars and bikes.

5. **Client**:
   - The `Client` class uses the factory to create cars and bikes without knowing the specific classes used to create them.

### Output:

When you run the `Program`, the output will be:

```plaintext
Honda Car manufactured.
Suzuki Bike manufactured.

Toyota Car manufactured.
Yamaha Bike manufactured.
```

This demonstrates how the Abstract Factory Pattern works, allowing the client to create products from a family without being aware of the specific classes used. The client only interacts with interfaces, promoting loose coupling and scalability.
