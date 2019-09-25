using System;
using System.Collections.Generic;
using System.Text;

namespace WS4_Cars_Static
{
    static class CarUtilities
    {
        public static double convertFromKilometersToMiles(double kph)
        {
            return 0.6213711922 * kph;
        }
    }
}
