using System;
using System.Collections.Generic;
using System.Text;

namespace WS4_Cars_Static
{
    class Car
    {
        // Add a static property for car count that keeps count of the number of cars created with this class. 
        private static int _carCount = 0;
        // Attributes (fields)
        // = private instance variables to store object data
        // Visible within class
        // Typically name in lowerCamelCase, starting with an underscore
        private string _model;
        private string plateNumber;
        private int _maxSpeed;
        private int _currentSpeed;
        private int _fuelCapacity;
        private int _remainingFuel;
        // Let's create a constant for max speed and set it to 240.
        // Constant names are typically spelt with uppercase letters.
        public const int MAX_SPEED = 240;

        // Constructor: no return value, not even void
        // Same name as the class
        // Parameters: Accepts plate number as a string as an input variable
        public Car(string plateNumber)
        {
            // If the attribute and input parameter have the same name, we need to use keyword this
            this.plateNumber = plateNumber;
            _carCount++;
        }

        // Methods
        // Sets the current speed to this instance
        // Returns a boolean depending on whether setting of the speed was successful or not
        public bool SetCurrentSpeed(int targetSpeed)
        {
            // If the given speed is less than zero or greater than max speed let's not set it and return false
            if (targetSpeed < 0 || targetSpeed > MAX_SPEED)
            {
                return false;
            }
            else
            {
                // Given speed ok -> Let's set it and return true
                _currentSpeed = targetSpeed;
                return true;
            }
        }

        // Gets current speed of this instance
        public int CheckCurrentSpeed()
        {
            return _currentSpeed;
        }

        // Gets plate number of this instance
        public string GetPlateNumber()
        {
            return plateNumber;
        }

        // Static getter for static property car count
        public static int GetCarCount()
        {
            return _carCount;
        }

        // Create a static constructor for Car class and make it initialise the number of cars to 1.
        static Car()
        {
            _carCount = 1;
        }
    }
}
