using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbter
{
    public class Lyrics
    {

        private string folderpath = null;

        public void SetImagesPath(string path)
        {
            this.folderpath = path;
        }

        private  int GetWidth(char st)
        {

            string Path = @""+folderpath+"/" + GetCharacter(st) + ".png";

            //Console.WriteLine(Path);
           // File.WriteAllText("file.txt",Path);
            int size = 0;
            if (File.Exists(Path))
            {
                Image img = new Bitmap(Path);
                size = img.Width;
            }

             if (st == 32)
            {
                size = 40;
            }
            return size;
        }

        private string GetCharacter(char oldChar)
        {

            string newChar = " ";
            if (oldChar >= 48 && oldChar <= 57 || oldChar >= 97 && oldChar <= 122)
            {
                newChar = oldChar.ToString();
            }

            else if (oldChar >= 65 && oldChar <= 90)
            {
                newChar = oldChar + "u";
            }

            else
            {
                newChar = ((int)(oldChar)).ToString();
            }
            //Console.WriteLine(newChar);
            return newChar;

        }

        private List<LyricsData> data = new List<LyricsData>();

        public List<LyricsData> ExtractLyrics(string lyric)
        {
            char[] chars = lyric.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if(chars[i]==32)             
                data.Add(new LyricsData { Character = GetCharacter(chars[i]), Width = 32});
                else
                data.Add(new LyricsData { Character = GetCharacter(chars[i]), Width = GetWidth(chars[i]) });
            }

            return data;
        }

    }

    public class LyricsData
    {
        public string Character { get; set; }
        public int  Width { get; set; }
    }

}
