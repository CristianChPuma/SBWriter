using System;
using System.Collections.Generic;
using System.IO;

namespace Sbter
{
    public class Note
    {
        private int start = 0;
        private string file = "";
        private List<string> lines = new List<string>();
        public Note(string filepath)
        {

            var lines_f = File.ReadAllLines(filepath);
            file = filepath;

            for(int i=0;i<lines_f.Length;i++)
            {
                if(lines_f[i].Contains("[HitObjects]"))
                {
                    start = i+1;
                    break;
                }
            }

            for (int j = start; j < lines_f.Length; j++)
            {
                lines.Add(lines_f[j]);
            }


        }

        private static List<string> GetColours(string path)
        {

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
  

            if (combos.Count == 0)
            {
                throw new Exception("There are not colors|Invalid file");
            }
            else {
                string c = combos[0];
                combos.Remove(combos[0]);
                combos.Insert((combos.Count), c);
                return combos;
            }
        }


        public List<NoteObject> GetObjects()
        {

            List<NoteObject> list_no = new List<NoteObject>();
            List<string> colors = GetColours(file);

            int hitsound = 0;
            int colorindex = 0;
            int index = 0;
            foreach (string l in lines)
            {

                var sp = l.Split(',');
                bool newcombo = false;

                if (sp[3] == "6")
                    newcombo = true;
                else
                    newcombo = false;

                var type = Convert.ToInt32(sp[3]);

                if ((type == 6 || type == 5))
                {

                    if (index == 0)
                    {
                        colorindex = 0;
                    }


                    else
                    {
                        if (colorindex >= colors.Count - 1)
                        {
                            colorindex = 0;
                        }
                        else {

                            colorindex++;
                        }
                     }
                }

                if (sp.Length > 8)
                {
                    var hitsound_slider = sp[8].Split('|');
                    hitsound = Convert.ToInt32(hitsound_slider[0]);
                    if ((hitsound == 4 || hitsound == 5))
                    {
                        // Console.WriteLine("Finish");
                    }
                    // break;
                }
                else {

                    hitsound = Convert.ToInt32(sp[4]);

                }

                var co = colors[colorindex].Split(',');


                list_no.Add(new NoteObject() { StartTime = Convert.ToInt32(sp[2]), X = Convert.ToInt32(sp[0]) + 64,
                    Y = Convert.ToInt32(sp[1]) + 56, NewCombo = newcombo, R = Convert.ToInt32(co[0]),
                    G = Convert.ToInt32(co[1]),
                    B = Convert.ToInt32(co[2])
                });

                index++;
            }

            return list_no;

        }

    }

    public class NoteObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int StartTime { get; set; }
        public bool NewCombo { get; set; }
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
    }

}
