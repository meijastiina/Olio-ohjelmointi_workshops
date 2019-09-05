using System;
using System.Collections.Generic;
using System.Text;

namespace WS1_1_Car
{
    class Car
    {
        // Attributes (fields)
        // = private instance variables to store object data
        // Visible within class
        private string Model;
        private string PlateNumber;
        private int MaxSpeed;
        private int CurrentSpeed;
        private int FuelCapacity;
        private int RemainingFuel;

        // Constructor
        public Car(string inputPlateNumber)
        {
            PlateNumber = inputPlateNumber;
        }

        // Methods
        // Sets the current speed to this instance
        public void SetCurrentSpeed(int targetSpeed)
        {
            CurrentSpeed = targetSpeed;
        }

        // Gets current speed of this instance
        public int CheckCurrentSpeed()
        {
            return CurrentSpeed;
        }

        // Gets plate number of this instance
        public string GetPlateNumber()
        {
            return PlateNumber;
        }
    }
}
