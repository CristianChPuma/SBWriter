using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbter.Utilities
{
    public class Timing
    {
        private int miliseconds;

        public Timing(string value)
        {
            string ms;
            if (value.Contains("-"))
            {
                ms = (value).Replace('-', ' ').Trim();
            }

            else
            {
                ms = (value).Trim();

            }

            var split = ms.Split(':');
            if (split.Length == 3)
            {
                TimeSpan t = new TimeSpan(0, 0, Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2]));
                miliseconds = Convert.ToInt32(t.TotalMilliseconds);
            }
            else
            {
                throw new Exception("Invalid value [minutes:seconds:miliseconds]");
            }


        }

        public override string ToString()
        {
            return miliseconds.ToString();
        }

        public int ToMiliseconds()
        {
            return miliseconds;
        }


        public static implicit operator Timing(string value)
        {
            return value == null ? null : new Timing(value);
        }

    }
}
