using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbter
{
    public static class Osw
    {

        static List<FullEvent> eve = new List<FullEvent>();
        public static void Save(string filepath, string layer, string origin,Event evet)
        {
            eve.Add(new FullEvent() { SpritePath = filepath, Layer = layer, Origin = origin, Actions = evet });
        }



        public static void Write(string output)
        {
            string json = JsonConvert.SerializeObject(eve, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            using (StreamWriter sw = new StreamWriter(output))
            { 
                sw.Write(json);
                sw.Close();
            }

        }



    }
}
