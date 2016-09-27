using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbter
{
    public class Sprite
    {

        public Event Eventes { get; set; }
        public FullEvent Actions { get; set; }

        public Sprite(string FilePath, Event Events)
        {
            Osw.Save(FilePath,Layer.Foreground,"Centre",Events);
        }

        public Sprite(string FilePath,string layer ,Event Events)
        {
            if (Layer.IsValidLayer(layer))
                Osw.Save(FilePath, layer, "Centre", Events);
            else
                throw new Exception("Invalid Layer, Check wrong spelling \r\n Available Layers: {Background,Failing,Passing,Foreground} ");
        }

        public Sprite(string FilePath, string layer, string Origin, Event Events)
        {
            if (Layer.IsValidLayer(layer))
                Osw.Save(FilePath,layer,Origin, Events);
            else
                throw new Exception("Invalid Layer, Check wrong spelling \r\n Available Layers: {Background,Failing,Passing,Foreground} ");
        }

    }
}
