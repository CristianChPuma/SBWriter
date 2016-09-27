using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sbter;
using Sbter.Utilities;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Storyboard
{
    class Program
    {
        #region Color#

        // static string path = @"C:\Program Files (x86)\osu!\Songs\Wilt - Verse Quence\Verse Quence (Mjq.Eri) - Wilt (XinCrin) [Insane].osu";

        /* public static void BG()
         {

             Sprite sp = new Sprite("BG.png", "Background");
             sp.Scale(0, 0.625);
             sp.Fade(0, 0, 6793, 0, 1);
             sp.Fade(0, 6793, 182413, 1, 1);
             sp.Set();
         }

         public static string[] GetColours(string path)
         {
             //string path = @"C:\Program Files (x86)\osu!\Songs\292814 SARINA PARIS - LOOK AT US (Daddy DJ Remix)\SARINA PARIS - LOOK AT US (Daddy DJ Remix) (Kazuya) [DANCE].osu";
             List<string> combos = new List<string>();
             if (File.Exists(path))
             {
                 string[] lines = File.ReadAllLines(path);
                 for (int i = 0; i < lines.Length; i++)
                 {

                     //If the line starts with "Combo", it will be added to the list 
                     if (lines[i].StartsWith("Combo"))
                     {

                         string[] combocolor = lines[i].Split(':');
                         combos.Add(combocolor[1]);
                     }

                 }
             }

             //Ordering the combo positions
                                      string c = combos[0];
             combos.Remove(combos[0]);
             combos.Insert((combos.Count), c);
             return combos.ToArray();
         }

         public static void GenerateLights(int start, int end, string path)
         {

             string[] colors = GetColours(path);

             string[] lines = File.ReadAllLines(path);

             int line_object = 0;
             int hitsound = 0;
             for (int i = 0; i < lines.Length; i++)
             {
                 if (lines[i].Equals("[HitObjects]"))
                 {
                     line_object = i + 1;
                 }


             }


             int colorindex = 0;
             int position = 0;
             for (int i = line_object; i < lines.Length; i++)
             {
                 var split = lines[i].Split(',');

                 int x = Convert.ToInt32(split[0]) + 64;
                 int y = Convert.ToInt32(split[1]) + 56;
                 int startTime = Convert.ToInt32(split[2]);
                 int type = Convert.ToInt32(split[3]);

                 if ((type == 6 || type == 5))
                 {

                     if (position == 0)
                     {
                         colorindex = 0;
                     }


                     else
                     {
                         if (colorindex >= colors.Length - 1)
                         {
                             colorindex = 0;
                         }
                         else {

                             colorindex++;
                         }
                     }

                 }

                 if (split.Length > 8)
                 {
                     // Console.WriteLine(lines[i]);
                     var hitsound_slider = split[8].Split('|');
                     hitsound = Convert.ToInt32(hitsound_slider[0]);
                     if ((hitsound == 4 || hitsound == 5))
                     {
                         // Console.WriteLine("Finish");
                     }
                     // break;
                 }
                 else {

                     hitsound = Convert.ToInt32(split[4]);

                 }


                 if (startTime >= start && startTime <= end)
                 {


                     //HitSounds:
                     //Clap: 8,9
                     //Finish: 4,5
                     //Whistle: 2,3
                     Sprite sp;
                     //Sprite sp2;
                     if ((hitsound == 4 || hitsound == 5))
                     {
                         sp = new Sprite("SB/shine.png");
                         sp.Move(startTime, (startTime + 160 * 4), x, y);
                         sp.Fade(startTime, (startTime + 160 * 4), 1, 0);
                     }
                     else {
                         sp = new Sprite("SB/shine.png");
                         sp.Move(startTime, (startTime + 160 * 4), x, y);
                         sp.Fade(startTime, (startTime + 160 * 4), 1, 0);
                     }


                     if ((hitsound == 4 || hitsound == 5))
                     {
                         sp.Scale(1, startTime, startTime + 600, 0.1, 0.8);

                     }
                     else {
                         sp.Scale(startTime, 1);
                     }

                     sp.Color(startTime, colors[colorindex]);
                     sp.Additive(startTime);
                     sp.Set();

                 }
                 position++;
             }


         }

            */

        #endregion#

            public static void a()
        {
            //new Spectrum(currentprojectmp3,bars,start(ms),end(ms),bpm)
            int bars = 50;
            int st = 0;
            int end = 64529;

            //use this.Mp3Path to get the current mp3 being used
            Spectrum sp = new Spectrum(@"C:\Program Files (x86)\osu!\Songs\Qin Ai De Na Bu Shi Ai Qing\audio.mp3", bars, st, end, 150);
            List<SpectrumData> fft = sp.GenerateData();
            //GenerateData() retrieves a SpectrumData object with frecuency values (start(ms)|end(ms)|fft)


            for (int i = 0; i < bars; i++)
            {
                List<Event> values = new List<Event>();
                for (int j = 0; j < fft.Count - 2; j++)
                {
                    double value1 = fft[j].Frecuencies[i];
                    double value2 = fft[j + 1].Frecuencies[i];
                    values.Add(new Event { 
                        V = new ScaleVec { Start = fft[j].StartTime, End = fft[j].EndTime, Vxi = 0.5, Vyi = value1, Vxf = 0.5, Vyf = value2 }
                   } );
                    //Console.WriteLine(fft[j].StartTime);
                }



                List<Event> s = new List<Event>();
                s.Add(new Event
                {
                    V = new ScaleVec { Start = 0, End = 2, Vxi = 3, Vyi = 4, Vxf = 0.5, Vyf = 1 }
                });

                Sprite bar = new Sprite("SB/bar.png",
                new Event
                {
                    MX = new MoveX { Start = 0, End = 0, Xi = (i * 10 + 40), Xf = (i * 10 + 40) },
                    F = new Fade { Start = st, End = st + 300, Fi = 0, Ff = 1 },
                    P = new Parameter { Start = st, Command = Command.A },
                    Custom = s
                });
                //  values.Clear();
                st += 10;
                // Sprite bar = new Sprite("SB/bar.png");
                // bar.MoveX(0, (i*10+40));
                // bar.Fade(0, st, st + 300,0,1);
                // bar.Additive(0);
                // for (int j=0;j<fft.Count-2;j++)
                // {
                //   double value1 = fft[j].Frecuencies[i];
                //   double value2 = fft[j+1].Frecuencies[i];
                //   bar.ScaleVec(0, fft[j].StartTime, fft[j].EndTime, 0.5, value1, 0.5, value2);
                // }
                // bar.Set(); //Saves the entire sprite
                // st += 10;
            }
        }

        public static void aa()
        {
            double a = Maths.Rand(10,20);
            Sprite sp = new Sprite("dot.png",
                new Event
                {
                    M = new Move {Start = 100, End = 20, Yf = a },
                    P = new Parameter { Start = 0, Command = Command.A }
                }
                
                );
        }

        static void Main(string[] args)
        {

            var code = File.ReadAllText("test.cs");
            Generator g = new Generator(code,"osb.txt","test.json");
            Console.WriteLine(g.GetError());
            if (g.GetError() == string.Empty)
            {
                Process.Start("osb.txt");
            }

            else
            {
                Console.WriteLine("Press any key to close");
                Console.ReadKey();
            }


        }

        

    }
}
