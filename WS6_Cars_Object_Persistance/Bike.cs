using System;

namespace WS6_Cars_Object_Persistance
{
    class Bike : Vehicle
    {
        static private int _bikeCount;
        // It's good coding practice to avoid "magic numbers" so let's define constants instead.
        private const int MIN_LETTERS_IN_PLATENUMBER = 2;
        private const int MAX_LETTERS_IN_PLATENUMBER = 3;
        private const int NUMBERS_IN_PLATENUMBER = 3;
        private const char SEPARATOR_IN_PLATENUMBER = '-';
        public Bike(string plateNumber, string colour, string model, int year, out bool success) : base(plateNumber, colour, model, year, out success)
        {
            if (success)
            {
                // Only increase the number of cars if successful
                _bikeCount++;
            }
        }
        static public int GetBikeCount()
        {
            return _bikeCount;
        }

        // Method to check that the given plate number consists of three letters and three numbers
        // Overrides the method in base class (override keyword)
        override protected bool CheckPlateNumber(string plateNumber)
        {
            // Plate number can contain 2-3 letters, a -, and three numbers
            bool retVal = (plateNumber.Length >= MIN_LETTERS_IN_PLATENUMBER + NUMBERS_IN_PLATENUMBER + 1 && plateNumber.Length <= MAX_LETTERS_IN_PLATENUMBER + NUMBERS_IN_PLATENUMBER + 1);
            // This could be done in a more elegant way but let's use structures we already know to check the plate number
            for (int i = 0; i < plateNumber.Length && retVal; i++)
            {
                // The first two or three characters need to be letters
                if (i < MIN_LETTERS_IN_PLATENUMBER)
                {
                    if (!Char.IsLetter(plateNumber[i]))
                    {
                        retVal = false;
                    }
                }
                // The thirs character can be either a letter or a '-'
                else if (i == MIN_LETTERS_IN_PLATENUMBER)
                {
                    if (Char.IsLetter(plateNumber[i]))
                    {
                        // It's a letter -> ok -> let's move on
                        i++;
                    }
                    if (plateNumber[i] != SEPARATOR_IN_PLATENUMBER)
                    {
                        retVal = false;
                    }
                }
                else
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
