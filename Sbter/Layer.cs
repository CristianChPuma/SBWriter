using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbter
{
    public class Layer
    {
        
        public static string Background { get; set; } = "Background";
        public static string Fail { get; set; } = "Failing";
        public static string Pass { get; set; } = "Passing";
        public static string Foreground { get; set; } = "Foreground";

        public static bool IsValidLayer(string layer)
        {
            if((layer=="Background") || (layer == "Failing") || (layer == "Passing") || (layer == "Foreground"))
            {
                return true;
            }
            return false;
        }

    }



}
