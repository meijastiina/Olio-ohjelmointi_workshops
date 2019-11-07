using System;
using System.Collections.Generic;

namespace WS6_Cars_Object_Persistance
{
    class Program
    {
        static void Main(string[] args)
        {
            // Let's create a list for vehicles (can store all types of vehicles)
            List<Vehicle> vehicles = new List<Vehicle>();
            // Let's get all the cars from db
            vehicles = CarQueries.getAllCars();

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
                        Console.Write("Colour: ");
                        string colour = Console.ReadLine();
                        Console.Write("Model: ");
                        string model = Console.ReadLine();
                        Console.Write("Year: ");
                        int year = int.Parse(Console.ReadLine());
                        if (car)
                        {
                            // Let's create a car
                            newVehicle = new Car(plateNumber,colour, model, year, out success);
                        }
                        else
                        {
                            // Let's create a bike
                            newVehicle = new Bike(plateNumber, colour, model, year, out success);
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
                            CarQueries.AddCar(newVehicle);
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
                    Console.WriteLine($"{ vehicle.GetPlateNumber() } / speed: { vehicle.GetCurrentSpeed() }\t\t colour:  { vehicle.GetColour() }\t\t model: { vehicle.GetModel() }\t\t year: { vehicle.GetYear() }.");
                }
                Console.WriteLine();
            } while (addVehicle);

        }
    }
}
