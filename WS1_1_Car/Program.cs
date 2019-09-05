using System;

namespace WS1_1_Car
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the Car class
            Car firstCar = new Car("OOP-001");
            // Set current speed
            firstCar.SetCurrentSpeed(120);
            // Print out info
            Console.WriteLine($"Car { firstCar.GetPlateNumber() } is driving { firstCar.CheckCurrentSpeed() } km/h");
            // Create another instance of the Car class
            Car secondCar = new Car("ABC-123");
            // Print out info
            Console.WriteLine($"Car { secondCar.GetPlateNumber() } is driving { secondCar.CheckCurrentSpeed() } km/h");
            // Set current speed
            secondCar.SetCurrentSpeed(100);
            // Print out info
            Console.WriteLine($"Car { secondCar.GetPlateNumber() } is driving { secondCar.CheckCurrentSpeed() } km/h");
        }
    }
}
