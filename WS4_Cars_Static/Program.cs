using System;
using System.Collections.Generic; // This is needed for lists.

namespace WS4_Cars_Static
{
    class Program
    {
        static void Main(string[] args)
        {
            // print out the value of the created static property
            Console.WriteLine($"Number of cars: { Car.GetCarCount() }");

            // Add three cars
            List<Car> cars = new List<Car>(); // Here we create a new instance of List class.
            cars.Add(new Car("HGR-987")); // To add items we use Add method.
            cars.Add(new Car("EFX-395"));
            cars.Add(new Car("EFX-395"));

            // and print out the value again to make sure it updates correctly.
            Console.WriteLine($"Number of cars: { Car.GetCarCount() }");

            // Print out the static constant MAX_VALUE
            Console.WriteLine($"Max speed for cars is { Car.MAX_SPEED} ");

            // Let's set the speed of the first car
            cars[0].SetCurrentSpeed(100);

            // Call static class's static method to convert kph to mph and format the output to have two decimals.
            Console.WriteLine($"Current speed of car { cars[0].GetPlateNumber() } is { cars[0].CheckCurrentSpeed() } kph which equals to { CarUtilities.convertFromKilometersToMiles(cars[0].CheckCurrentSpeed()):0.##} mph.");

        }
    }
}
