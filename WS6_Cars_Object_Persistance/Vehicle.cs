using System;
using System.Collections.Generic;
using System.Text;

namespace WS6_Cars_Object_Persistance
{
    // Vehicle is an abstract class -> You can't create instances of it directly
    abstract class Vehicle
    {
        // Add a static property for car count that keeps count of the number of cars created with this class. 
        private static int _vehicleCount = 0;
        // Attributes (fields)
        // = private instance variables to store object data
        // Visible within class
        // Typically name in lowerCamelCase, starting with an underscore
        private string _plateNumber;
        private string _colour;
        private string _model;
        private int _year;
        private int _currentSpeed;
        // Let's create a constant for max speed and set it to 240.
        // Constant names are typically spelt with uppercase letters.
        private const int MAX_SPEED = 240;

        // Constructor: no return value, not even void
        // Same name as the class
        // Parameters: Accepts plate number as a string as an input variable
        //          We're using an out parameter here as well to return info to the calling method about whether the 
        //          plate number was valid (constructor can't have a return value). 
        //          A better way would be to throw an exception but since we
        //          haven's learned to use them as of yet, we'll do with this for now.
        public Vehicle(string plateNumber, string colour, string model, int year, out bool success)
        {
            if (CheckPlateNumber(plateNumber))
            {
                SetPlateNumber(plateNumber);
                _colour = colour;
                _model = model;
                _year = year;
                _vehicleCount++;
                success = true;
            } else
            {
                success = false;
            }
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
        // By default we assume plate number is ok. 
        // However, the derived classes can override this method with their own implementation (virtual keyword).
        // We only want to use this method within the class and its child classes -> protected, not public
        protected virtual bool CheckPlateNumber(string plateNumber)
        {
            return true;
        }

        // Gets current speed of this instance
        public int GetCurrentSpeed()
        {
            return _currentSpeed;
        }
        // Checks the plate number and sets it if it's valid
        public bool SetPlateNumber(string plateNumber)
        {
            bool retVal = false;
            if (CheckPlateNumber(plateNumber))
            {
                _plateNumber = plateNumber;
                retVal = true;
            }
            return retVal;
        }
        // Gets plate number of this instance
        public string GetPlateNumber()
        {
            return _plateNumber;
        }

        // Static getter for static property car count
        public static int GetVehicleCount()
        {
            return _vehicleCount;
        }

        public string GetModel()
        {
            return _model;
        }
        public string GetColour()
        {
            return _colour;
        }

        public int GetYear()
        {
            return _year;
        }
    }
}
