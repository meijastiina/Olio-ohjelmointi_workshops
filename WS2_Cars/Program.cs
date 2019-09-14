using System;

namespace WS2_Car
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize an array with 3 Car objects. Use the constructor to set the plateNr. Hardcode the plate numbers to: (“HGR-987”, “EFX-395”, “EFX-395”)
            Car[] cars = new Car[3];
            cars[0] = new Car("HGR-987");
            cars[1] = new Car("EFX-395");
            cars[2] = new Car("EFX-395");
            //After the array is initialized, the program asks from the user via the command prompt the speed for each car, and sets the speed for the car calling the method SetCurrentSpeed
            for (int i = 0; i < cars.Length; i++)
            {
                Console.Write($"Enter the speed of car { cars[i].GetPlateNumber() }: ");
                //If the user has provided an invalid speed (SetCurrentSpeed returns “false”), the program will notify that the speed is invalid and will ask the speed again
                while(!cars[i].SetCurrentSpeed(int.Parse(Console.ReadLine())))
                {
                    Console.WriteLine("Invalid speed!");
                    Console.Write($"Enter the speed of car { cars[i].GetPlateNumber() }: ");
                }
            }
            //After all the speeds are successfully set, the program will calculate the speed average of all three cars and print to the screen:“The average speed of cars is xxx Km/h”
            int averageSpeed = 0;
            for (int i = 0; i < cars.Length; i++)
            {
                // Let's sum up all car speeds
                averageSpeed += cars[i].CheckCurrentSpeed();
            }
            // Let's divide the sum by the number of cars.
            averageSpeed = averageSpeed / cars.Length;
            Console.WriteLine($"The average speed of cars is { averageSpeed } Km/h");
        }
    }
}
