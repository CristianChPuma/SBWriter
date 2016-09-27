using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbter
{

    public class FullEvent
    {
        public string SpritePath { get; set; }
        public string Layer { get; set; }
        public string Origin { get; set; }
        public Event Actions { get; set; }
    }

    public class Event
    {
        public Move M { get; set; }
        public MoveX MX { get; set; }
        public MoveY MY { get; set; }
        public Fade F { get; set; }
        public Scale S { get; set; }
        public Rotate R { get; set; }
        public Color C { get; set; }
        public Loop L { get; set; }
        public TriggerLoop T { get; set; }
        public ScaleVec V { get; set; }
        public Parameter P { get; set; }
        public List<Move> ML { get; set; }
        public List<MoveX> MXL { get; set; }
        public List<MoveY> MYL { get; set; }
        public List<Scale> SL { get; set; }
        public List<Fade> FL { get; set; }
        public List<Rotate> RL { get; set; }
        public List<Color> CL { get; set; }
        public List<ScaleVec> VL { get; set; }
        public List<Parameter> PL { get; set; }
        public List<Event> Custom { get; set; }
    }


    public class Loop
    {
        public int Start { get; set; }
        public int Times { get; set; }
        public Event Events { get; set; }
    }

    public class TriggerLoop
    {
        public string Trigger { get; set; }
        public int Start { get; set; } = 0;
        public int End { get; set; } = 0;
        public Event Events { get; set; }
    }





    public class Move
    {
        public int Easing { get; set; } = 0;
        public int Start { get; set; }
        public int End { get; set; }
        public double Xi { get; set; }
        public double Yi { get; set; }
        public double Xf { get; set; }
        public double Yf { get; set; }
        // public bool Loop { get; set; }
    }

    public class MoveX
    {
        public int Easing { get; set; } = 0;
        public int Start { get; set; }
        public int End { get; set; }
        public double Xi { get; set; }
        public double Xf { get; set; }
        //  public bool Loop { get; set; }
    }

    public class MoveY
    {
        public int Easing { get; set; } = 0;
        public int Start { get; set; }
        public int End { get; set; }
        public double Yi { get; set; }
        public double Yf { get; set; }
        //  public bool Loop { get; set; }
    }

    public class Fade
    {
        public int Easing { get; set; } = 0;
        public int Start { get; set; }
        public int End { get; set; }
        public double Fi { get; set; }
        public double Ff { get; set; }
        // public bool Loop { get; set; }
    }

    public class Scale
    {
        public int Easing { get; set; } = 0;
        public int Start { get; set; }
        public int End { get; set; }
        public double Si { get; set; }
        public double Sf { get; set; }
        //  public bool Loop { get; set; }
    }

    public class Rotate
    {
        public int Easing { get; set; } = 0;
        public int Start { get; set; }
        public int End { get; set; }
        public double Ri { get; set; }
        public double Rf { get; set; }
        //   public bool Loop { get; set; }
    }

    public class ScaleVec
    {
        public int Easing { get; set; } = 0;
        public int Start { get; set; }
        public int End { get; set; }
        public double Vxi { get; set; }
        public double Vyi { get; set; }
        public double Vxf { get; set; }
        public double Vyf { get; set; }
        //  public bool Loop { get; set; }
    }

    public class Color
    {
        public int Easing { get; set; } = 0;
        public int Start { get; set; }
        public int End { get; set; }
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
        public int Rf { get; set; }
        public int Gf { get; set; }
        public int Bf { get; set; }
        //  public bool Loop { get; set; }
    }




    public class Parameter
    {
        public int Start { get; set; }
        public string Command { get; set; }
    }

    public class Command
    {
        public static string A { get; set; } = "A";
        public static string H { get; set; } = "H";
        public static string V { get; set; } = "V";
    }

}
