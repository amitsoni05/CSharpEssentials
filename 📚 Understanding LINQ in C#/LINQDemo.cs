using System;
using System.Linq;

namespace LINQDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define an array of ages
            int[] ages = { 12, 23, 21, 22, 45, 33, 20, 26, 55, 66 };

            // LINQ query to filter and sort data
            var results = from age in ages
                          where age > 20
                          orderby age // Default is ascending
                          select age;

            // Display the results
            foreach (var age in results)
            {
                Console.WriteLine(age);
            }

            // Hold the console window open
            Console.ReadLine();
        }
    }
}
