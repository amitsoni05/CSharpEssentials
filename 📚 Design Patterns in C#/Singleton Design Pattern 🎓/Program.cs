using System;

namespace SingletonDesignPattern
{
    // Singleton class
    public class MyClass
    {
        // Private static instance of the class
        private static MyClass _instance;

        // Private constructor to prevent instantiation from other classes
        private MyClass()
        {
            Console.WriteLine("Singleton instance created!");
        }

        // Public static method to provide a global access point to the instance
        public static MyClass Instance
        {
            get
            {
                // Create a new instance if it doesn't exist
                if (_instance == null)
                {
                    _instance = new MyClass();
                }
                // Return the single instance
                return _instance;
            }
        }

        // Example method to demonstrate the Singleton behavior
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

    // Class to demonstrate usage of the Singleton pattern
    public class Program
    {
        static void Main(string[] args)
        {
            // Attempt to create multiple instances
            MyClass instance1 = MyClass.Instance;
            instance1.DisplayMessage("Instance 1: Singleton Pattern in Action!");

            MyClass instance2 = MyClass.Instance;
            instance2.DisplayMessage("Instance 2: Singleton Pattern in Action!");

            // Check if both instances are the same
            if (instance1 == instance2)
            {
                Console.WriteLine("Both instances are the same, Singleton works!");
            }
            else
            {
                Console.WriteLine("Instances are different, Singleton failed.");
            }
        }
    }
}
