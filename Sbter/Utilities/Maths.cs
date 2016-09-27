using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbter.Utilities
{
    public class Maths
    {

        static Random randomizer = new Random();
        public static double Rand(double minimum, double maximum)
        {

            return Math.Round(minimum + randomizer.NextDouble() * (maximum - minimum), 2);
        }

    }
}
