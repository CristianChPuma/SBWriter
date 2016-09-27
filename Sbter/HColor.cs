using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbter
{
    public class HColor
    {

        private string color;
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }

        public HColor(string value)
        {
            string[] rgb = new string[3];

            if (value.Contains("#"))
            {
                color = value.Replace("#", "").Trim(); ;
            }
            else
            {
                color = value.Trim();
            }

            if (color.Length == 6)
            {
                rgb[0] = color.Substring(0, 2);
                rgb[1] = color.Substring(2, 2);
                rgb[2] = color.Substring(4, 2);

                R = Convert.ToInt32(rgb[0], 16);
                G = Convert.ToInt32(rgb[1], 16);
                B = Convert.ToInt32(rgb[2], 16);
            }else
            {
                throw new Exception("Invalid color code");
            }

        }

        public override string ToString()
        {
            string newcolor = R+","+G+","+B;
            return newcolor;
        }



        public static implicit operator HColor(string value)
        {
            return value == null ? null : new HColor(value);
        }

    }
}
