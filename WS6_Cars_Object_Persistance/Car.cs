using System;

namespace WS6_Cars_Object_Persistance
{
    class Car : Vehicle
    {
        // Add a static property for car count that keeps count of the number of cars created with this class. 
        private static int _carCount = 0;
        // It's good coding practice to avoid "magic numbers" so let's define constants instead.
        private const int LETTERS_IN_PLATENUMBER = 3;
        private const int NUMBERS_IN_PLATENUMBER = 3;
        private const char SEPARATOR_IN_PLATENUMBER = '-';
        // Let's use base class's constructor since it's the same for all derived classes.
        public Car(string plateNumber, string colour, string model, int year, out bool success) : base(plateNumber, colour, model, year, out success)
        {
            if (success)
            {
                // Only increase the number of cars if successful
                _carCount++;
            }
        }
        // Static getter for static property car count
        public static int GetCarCount()
        {
            return _carCount;
        }
        // Method to check that the given plate number consists of three letters and three numbers
        // Overrides the method in base class (override keyword)
        override protected bool CheckPlateNumber(string plateNumber)
        {
            // Plate number must be 7 characters long (aaa-999)
            bool retVal = plateNumber.Length == LETTERS_IN_PLATENUMBER + NUMBERS_IN_PLATENUMBER + 1; 
            // This could be done in a more elegant way but let's use structures we already know to check the plate number
            for (int i = 0; i < plateNumber.Length && retVal; i++)
            {
                // The first three characters need to be letters
                if (i < LETTERS_IN_PLATENUMBER)
                {
                    if (!Char.IsLetter(plateNumber[i]))
                    {
                        retVal = false;
                    }
                }
                // The fourth character needs to be -
                else if (i == LETTERS_IN_PLATENUMBER)
                {
                    if (plateNumber[i] != SEPARATOR_IN_PLATENUMBER)
                    {
                        retVal = false;
                    }
                } else
                {
                    if (!Char.IsNumber(plateNumber[i]))
                    {
                        retVal = false;
                    }
                }
            }
            return retVal;
        }
    }
}
