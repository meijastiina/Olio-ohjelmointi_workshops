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
        // Typically name in lowerCamelCase, starting with an underscore
        private string _model; 
        private string _plateNumber;
        private int _maxSpeed;
        private int _currentSpeed;
        private int _fuelCapacity;
        private int _remainingFuel;

        // Constructor: no return value, not even void
        // Same name as the class
        // Parameters: Accepts plate number as a string as an input variable
        public Car(string inputPlateNumber)
        {
            _plateNumber = inputPlateNumber;
        }

        // Methods
        // Sets the current speed to this instance
        public void SetCurrentSpeed(int targetSpeed)
        {
            _currentSpeed = targetSpeed;
        }

        // Gets current speed of this instance
        public int CheckCurrentSpeed()
        {
            return _currentSpeed;
        }

        // Gets plate number of this instance
        public string GetPlateNumber()
        {
            return _plateNumber;
        }
    }
}
