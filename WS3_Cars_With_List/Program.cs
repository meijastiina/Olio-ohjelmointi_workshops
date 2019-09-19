using System;
using System.Collections.Generic; // This is needed for lists.

namespace WS3_Cars_With_List
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize a generic list with 3 Car objects. Use the constructor to set the plateNr. Hardcode the plate numbers to: (“HGR-987”, “EFX-395”, “EFX-395”)
            List<Car> cars = new List<Car>(); // Here we create a new instance of List class.
            cars.Add(new Car("HGR-987")); // To add items we use Add method.
            cars.Add(new Car("EFX-395"));
            cars.Add(new Car("EFX-395"));
            int averageSpeed = 0;
            //After the list is initialized, the program asks from the user via the command prompt the speed for each car, and sets the speed for the car calling the method SetCurrentSpeed
            foreach ( Car car in cars) // Instead of for loop, let's use foreach
            {
                Console.Write($"Enter the speed of car { car.GetPlateNumber() }: ");
                //If the user has provided an invalid speed (SetCurrentSpeed returns “false”), the program will notify that the speed is invalid and will ask the speed again
                while (!car.SetCurrentSpeed(int.Parse(Console.ReadLine())))
                {
                    Console.WriteLine("Invalid speed!");
                    Console.Write($"Enter the speed of car { car.GetPlateNumber() }: ");
                }
                //After all the speeds are successfully set, the program will calculate the speed average of all three cars and print to the screen:“The average speed of cars is xxx Km/h”
                averageSpeed += car.CheckCurrentSpeed(); //Let's refactor a little and calculate the sum here so we don't need two loops.
            }

            // Let's divide the sum by the number of cars.
            averageSpeed = averageSpeed / cars.Count; // Instead of length, here we use Count.
            Console.WriteLine($"The average speed of cars is { averageSpeed } Km/h");
        }
    }
}
