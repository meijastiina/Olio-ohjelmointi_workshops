using System;
using System.Collections.Generic; // This is needed for lists

namespace WS5_Cars_Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            // Let's create a list for vehicles (can store all types of vehicles)
            List<Vehicle> vehicles = new List<Vehicle>();
            string plateNumber;
            int speed;
            bool addVehicle, success = false, car;
            Vehicle newVehicle;
            // Let's keep looping till the user says no
            do
            {
                Console.Write("Enter a new vehicle? (y/n)");
                addVehicle = Char.Parse(Console.ReadLine()) == 'y';
                // User wants to enter a new vehicle
                if (addVehicle)
                {
                    Console.WriteLine("Enter a car or a bike? (c/b)");
                    car = Char.Parse(Console.ReadLine()) == 'c';
                    // Keep asking till the user enters a valid plate number
                    do
                    {
                        Console.Write("Platenumber: ");
                        plateNumber = Console.ReadLine();
                        if (car)
                        {
                            // Let's create a car
                            newVehicle = new Car(plateNumber, out success);
                        }
                        else
                        {
                            // Let's create a bike
                            newVehicle = new Bike(plateNumber, out success);
                        }
                        if (!success)
                        {
                            Console.WriteLine($"Invalid plate number");
                        }
                        else
                        {
                            Console.Write("Current speed: ");
                            speed = int.Parse(Console.ReadLine());
                            newVehicle.SetCurrentSpeed(speed);
                            vehicles.Add(newVehicle);
                        }
                    } while (!success);

                }
                // Let's print out the info about created vehicles
                Console.WriteLine();
                Console.WriteLine("******* VEHICLES *********");
                Console.WriteLine($"Number of cars: { Car.GetCarCount() }.");
                Console.WriteLine($"Number of bikes: { Bike.GetBikeCount() }.");
                Console.WriteLine($"Number of vehicles: { Vehicle.GetVehicleCount() }.");
                foreach (Vehicle vehicle in vehicles)
                {
                    Console.WriteLine($"{ vehicle.GetPlateNumber() }: speed { vehicle.GetCurrentSpeed() }.");
                }
                Console.WriteLine();
            } while (addVehicle);
        }
    }
}
