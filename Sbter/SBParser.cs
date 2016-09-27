using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbter
{
    public class SBParser
    {
        List<FullEvent> storyboard = new List<FullEvent>();
        StringBuilder bg = new StringBuilder();
        StringBuilder fl = new StringBuilder();
        StringBuilder ps = new StringBuilder();
        StringBuilder fg = new StringBuilder();

        public SBParser(string input)
        {
            storyboard = JsonConvert.DeserializeObject<List<FullEvent>>(input);
            DoWork();
        }

        public void DoWork()

        {



            var fe = storyboard;

            for (int hi = 0; hi < fe.Count; hi++)
            {
                //Console.WriteLine("Sprite," + fe[i].Layer + "," + fe[i].Origin + ",\"" + fe[i].SpritePath + "\",320,240");
                STe st = new STe(fe[hi].SpritePath,fe[hi].Layer,fe[hi].Origin);
                var Actions = fe[hi].Actions;
                var a = fe[hi].Actions;
                #region SimpleSprite#
                if (Actions.M != null)
                {
                    st.Move(a.M.Easing,a.M.Start,a.M.End,a.M.Xi,a.M.Yi,a.M.Xf,a.M.Yf);
                    //Console.WriteLine(" M," + Actions.M.Start);
                }

                if (Actions.MX != null)
                {
                    st.MoveX(a.MX.Easing, a.MX.Start, a.MX.End, a.MX.Xi, a.MX.Xf);
                    //Console.WriteLine(" MX," + Actions.MX.Start);
                }

                if (Actions.MY != null)
                {
                    st.MoveY(a.MY.Easing, a.MY.Start, a.MY.End, a.MY.Yi, a.MY.Yf);
                    //Console.WriteLine(" MY," + Actions.MY.Start);
                }

                if (Actions.F != null)
                {
                    st.Fade(a.F.Easing, a.F.Start, a.F.End, a.F.Fi, a.F.Ff);
                    //Console.WriteLine(" F," + Actions.F.Start);
                }

                if (Actions.S != null)
                {
                    st.Scale(a.S.Easing, a.S.Start, a.S.End, a.S.Si, a.S.Sf);
                   // Console.WriteLine(" S," + Actions.S.Start);
                }

                if (Actions.C != null)
                {
                    st.Color(a.C.Easing, a.C.Start, a.C.End, a.C.R, a.C.G,a.C.B, a.C.Rf, a.C.Gf, a.C.Bf);
                   // Console.WriteLine(" C," + Actions.C.R);
                }

                if (Actions.V != null)
                {
                    st.ScaleVec(a.V.Easing, a.V.Start, a.V.End, a.V.Vxi, a.V.Vyi,a.V.Vxf,a.V.Vyf);
                   // Console.WriteLine(" V," + Actions.C.Start);
                }

                if (Actions.P != null)
                {
                    switch (Actions.P.Command) {
                      case "A":   
                       st.Additive(a.P.Start);
                        break;
                        case "H":
                            st.FlipH(a.P.Start);
                            break;
                        case "V":
                            st.FlipV(a.P.Start);
                            break;
                    }
                }
       

                #endregion#
                #region Lists#
                if (Actions.ML != null)
                {
                    for (int i = 0; i < Actions.ML.Count; i++)
                        st.Move(a.ML[i].Easing, a.ML[i].Start, a.ML[i].End, a.ML[i].Xi, a.ML[i].Yi, a.ML[i].Xf, a.ML[i].Yf);
                }

                if (Actions.MXL != null)
                {
                    for (int i = 0; i < Actions.MXL.Count; i++)
                        st.MoveX(a.MXL[i].Easing, a.MXL[i].Start, a.MXL[i].End, a.MXL[i].Xi, a.MXL[i].Xf);
                }

                if (Actions.MYL != null)
                {
                    for (int i = 0; i < Actions.MYL.Count; i++)
                        st.MoveX(a.MYL[i].Easing, a.MYL[i].Start, a.MYL[i].End, a.MYL[i].Yi, a.MYL[i].Yf);
                }

                if (Actions.FL != null)
                {
                    for (int i = 0; i < Actions.FL.Count; i++)
                        st.Fade(a.FL[i].Easing, a.FL[i].Start, a.FL[i].End, a.FL[i].Fi, a.FL[i].Ff);
                }

                if (Actions.SL != null)
                {
                    for (int i = 0; i < Actions.SL.Count; i++)
                        st.Scale(a.SL[i].Easing, a.SL[i].Start, a.SL[i].End, a.SL[i].Si, a.SL[i].Sf);
                }

                if (Actions.CL != null)
                {
                    for (int i = 0; i < Actions.CL.Count; i++)
                        st.Color(a.CL[i].Easing, a.CL[i].Start, a.CL[i].End, a.CL[i].R, a.CL[i].G, a.CL[i].B, a.CL[i].Rf, a.CL[i].Gf, a.CL[i].Bf);
                }

                if (Actions.VL != null)
                {
                    for (int i = 0; i < Actions.VL.Count; i++)
                    st.ScaleVec(a.VL[i].Easing, a.VL[i].Start, a.VL[i].End, a.VL[i].Vxi, a.VL[i].Vyi, a.VL[i].Vxf, a.VL[i].Vyf);
                }

                if (Actions.PL != null)
                {
                    for (int i = 0; i < Actions.PL.Count; i++)
                    {
                        switch (Actions.PL[i].Command)
                        {
                            case "A":
                                st.Additive(a.PL[i].Start);
                                break;
                            case "H":
                                st.FlipH(a.PL[i].Start);
                                break;
                            case "V":
                                st.FlipV(a.PL[i].Start);
                                break;
                        }
                    }
                }

                #endregion#
                #region Loops#


                if (Actions.L!= null)
                {
                    var al = Actions.L.Events;
                    if (Actions.L != null)
                        st.Loop(Actions.L.Start, Actions.L.Times);

                    if (al.M != null)
                    {
                        st.Move(al.M.Easing, al.M.Start, al.M.End, al.M.Xi, al.M.Yi, al.M.Xf, al.M.Yf,true);
                        //Console.WriteLine(" M," + Actions.M.Start);
                    }

                    if (al.MX != null)
                    {
                        st.MoveX(al.M.Easing, al.MX.Start, al.MX.End, al.MX.Xi, al.MX.Xf, true);
                        //Console.WriteLine(" MX," + Actions.MX.Start);
                    }

                    if (al.MY != null)
                    {
                        st.MoveY(al.M.Easing, al.MY.Start, al.MY.End, al.MY.Yi, al.MY.Yf, true);
                        //Console.WriteLine(" MY," + Actions.MY.Start);
                    }

                    if (al.F != null)
                    {
                        st.Fade(al.F.Easing, al.F.Start, al.F.End, al.F.Fi, al.F.Ff, true);
                        //Console.WriteLine(" F," + Actions.F.Start);
                    }

                    if (al.S != null)
                    {
                        st.Scale(al.S.Easing, al.S.Start, al.S.End, al.S.Si, al.S.Sf, true);
                        // Console.WriteLine(" S," + Actions.S.Start);
                    }

                    if (al.C != null)
                    {
                        st.Color(al.C.Easing, al.C.Start, al.C.End, al.C.R, al.C.G, al.C.B, al.C.Rf, al.C.Gf, al.C.Bf, true);
                        // Console.WriteLine(" C," + Actions.C.R);
                    }

                    if (al.V != null)
                    {
                        st.ScaleVec(al.V.Easing, al.V.Start, al.V.End, al.V.Vxi, al.V.Vyi, al.V.Vxf, al.V.Vyf, true);
                        // Console.WriteLine(" V," + Actions.C.Start);
                    }

                    if (al.P != null)
                    {
                        switch (al.P.Command)
                        {
                            case "A":
                                st.Additive(al.P.Start);
                                break;
                            case "H":
                                st.FlipH(al.P.Start);
                                break;
                            case "V":
                                st.FlipV(al.P.Start);
                                break;
                        }
                    }

                }
                #endregion#
                #region TLoops#
                if (Actions.T != null)
                {
                    var al2 = Actions.T.Events;
                    if(Actions.T != null)
                    st.TriggerLoop(Actions.T.Trigger, Actions.T.Start, Actions.T.End);
                    //Console.WriteLine(al2.T.Trigger);
                    #region SimpleSprite#
                    if (al2.M != null)
                    {
                        st.Move(al2.M.Easing, al2.M.Start, al2.M.End, al2.M.Xi, al2.M.Yi, al2.M.Xf, al2.M.Yf, true);
                        //Console.WriteLine(" M," + Actions.M.Start);
                    }

                    if (al2.MX != null)
                    {
                        st.MoveX(al2.M.Easing, al2.MX.Start, al2.MX.End, al2.MX.Xi, al2.MX.Xf, true);
                        //Console.WriteLine(" MX," + Actions.MX.Start);
                    }

                    if (al2.MY != null)
                    {
                        st.MoveY(al2.M.Easing, al2.MY.Start, al2.MY.End, al2.MY.Yi, al2.MY.Yf, true);
                        //Console.WriteLine(" MY," + Actions.MY.Start);
                    }

                    if (al2.F != null)
                    {
                        st.Fade(al2.F.Easing, al2.F.Start, al2.F.End, al2.F.Fi, al2.F.Ff, true);
                        //Console.WriteLine(" F," + Actions.F.Start);
                    }

                    if (al2.S != null)
                    {
                        st.Scale(al2.S.Easing, al2.S.Start, al2.S.End, al2.S.Si, al2.S.Sf, true);
                        // Console.WriteLine(" S," + Actions.S.Start);
                    }

                    if (al2.C != null)
                    {
                        st.Color(al2.C.Easing, al2.C.Start, al2.C.End, al2.C.R, al2.C.G, al2.C.B, al2.C.Rf, al2.C.Gf, al2.C.Bf, true);
                        // Console.WriteLine(" C," + Actions.C.R);
                    }

                    if (al2.V != null)
                    {
                        st.ScaleVec(al2.V.Easing, al2.V.Start, al2.V.End, al2.V.Vxi, al2.V.Vyi, al2.V.Vxf, al2.V.Vyf, true);
                        // Console.WriteLine(" V," + Actions.C.Start);
                    }

                    if (al2.P != null)
                    {
                        switch (al2.P.Command)
                        {
                            case "A":
                                st.Additive(al2.P.Start);
                                break;
                            case "H":
                                st.FlipH(al2.P.Start);
                                break;
                            case "V":
                                st.FlipV(al2.P.Start);
                                break;
                        }
                    }

                }

                #endregion#
                #endregion#

                #region CustomLists#

                if (Actions.Custom != null)

                    for (int i = 0; i < Actions.Custom.Count; i++)
                    {
                        var ac = Actions.Custom[i];
                        if (Actions.Custom[i].M != null)
                        {
                                st.Move(ac.M.Easing, ac.M.Start, ac.M.End, ac.M.Xi, ac.M.Yi, ac.M.Xf, ac.M.Yf);
                            //Console.WriteLine(" M," + Actions.M.Start);
                        }

                        if (Actions.Custom[i].MX != null)
                        {
                                st.MoveX(ac.MX.Easing, ac.MX.Start, ac.MX.End, ac.MX.Xi, ac.MX.Xf);
                            //Console.WriteLine(" MX," + Actions.Custom[i]MX.Start);
                        }

                        if (Actions.Custom[i].MY != null)
                        {
                                st.MoveY(ac.MY.Easing, ac.MY.Start, ac.MY.End, ac.MY.Yi, ac.MY.Yf);
                            //Console.WriteLine(" MY," + Actions.Custom[i]MY.Start);
                        }

                        if (Actions.Custom[i].F != null)
                        {
                            st.Fade(ac.F.Easing, ac.F.Start, ac.F.End, ac.F.Fi, ac.F.Ff);
                            //Console.WriteLine(" F," + Actions.Custom[i]F.Start);
                        }

                        if (Actions.Custom[i].S != null)
                        {
                            st.Scale(ac.S.Easing, ac.S.Start, ac.S.End, ac.S.Si, ac.S.Sf);
                            // Console.WriteLine(" S," + Actions.Custom[i]S.Start);
                        }

                        if (Actions.Custom[i].C != null)
                        {
                            st.Color(ac.C.Easing, ac.C.Start, ac.C.End, ac.C.R, ac.C.G, ac.C.B, ac.C.Rf, ac.C.Gf, ac.C.Bf);
                            // Console.WriteLine(" C," + Actions.Custom[i]C.R);
                        }

                        if (Actions.Custom[i].V != null)
                        {
                            st.ScaleVec(ac.V.Easing, ac.V.Start, ac.V.End, ac.V.Vxi, ac.V.Vyi, ac.V.Vxf, ac.V.Vyf);
                            // Console.WriteLine(" V," + Actions.Custom[i]C.Start);
                        }

                        if (Actions.Custom[i].P != null)
                        {
                            switch (Actions.Custom[i].P.Command)
                            {
                                case "A":
                                    st.Additive(ac.P.Start);
                                    break;
                                case "H":
                                    st.FlipH(ac.P.Start);
                                    break;
                                case "V":
                                    st.FlipV(ac.P.Start);
                                    break;
                            }
                        }

                    }
                #endregion#

                if (fe[hi].Layer=="Background")
                {
                    bg.Append(st.GetOSB());
                }

                if (fe[hi].Layer == "Failing")
                {
                    fl.Append(st.GetOSB());
                }

                if (fe[hi].Layer == "Passing")
                {
                    ps.Append(st.GetOSB());
                }

                if (fe[hi].Layer == "Foreground")
                {
                    fg.Append(st.GetOSB());
                }

            }

        }

        public void WriteToOsb(string osbfile)
        {
                StreamWriter sw = new StreamWriter(osbfile);
                sw.Write("[Events]\r\n" +
                         "//Background and Video events\r\n" +
                         "//Storyboard Layer 0 (Background)\r\n");
                sw.Write(bg.ToString());
                sw.Write("//Storyboard Layer 1 (Fail)\r\n");
                sw.Write(fl.ToString());
                sw.Write("//Storyboard Layer 2 (Pass)\r\n");
                sw.Write(ps.ToString());
                sw.Write("//Storyboard Layer 3 (Foreground)\r\n");
                sw.Write(fg.ToString());
                sw.Write("//Storyboard Sound Samples\r\n");
                sw.Close();
                bg.Clear();
                fl.Clear();
                ps.Clear();
                fg.Clear();
        }


        public void GetList(Event Actions)
        {
           

            //Console.WriteLine();

        }

        public List<FullEvent> GetSB()
        {

            return storyboard;

        }

    }

    public class STe
    {


        StringBuilder sb = new StringBuilder();
        string layer = "Foreground";
        #region Constructors#

        public STe(string filepath)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
            sb.Append("Sprite,Foreground,Centre,\"" + filepath + "\",320,240\r\n");
            this.layer = "Foreground";
        }

        public STe(string filepath, string layer)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
            sb.Append("Sprite," + layer + ",Centre,\"" + filepath + "\",320,240\r\n");
            this.layer = layer;
        }

        public STe(string filepath, string layer, string origin)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
            sb.Append("Sprite," + layer + "," + origin + ",\"" + filepath + "\",320,240\r\n");
            this.layer = layer;
        }

        #endregion#

        #region Move#

        public void Move(int startTime, int endTime, double x, double y)
        {
            sb.Append(" M,0," + startTime + ",," + x + "," + y + "\r\n");
        }

        public void Move(int easing, int startTime, int endTime, double xi, double yi, double xf, double yf)
        {
            sb.Append(" M," + easing + "," + startTime + "," + endTime + "," + xi + "," + yi + "," + xf + "," + yf + "\r\n");
        }

        public void Move(int easing, int startTime, int endTime, double xi, double yi, double xf, double yf, bool Loop)
        {
            if (Loop == true)
                sb.Append("  M," + easing + "," + startTime + "," + endTime + "," + xi + "," + yi + "," + xf + "," + yf + "\r\n");
            else
                sb.Append("  M," + easing + "," + startTime + "," + endTime + "," + xi + "," + yi + "," + xf + "," + yf + "\r\n");
        }


        #endregion#

        #region MoveX#

        public void MoveX(int startTime, double x)
        {
            sb.Append(" MX,0," + startTime + ",," + x + "\r\n");
        }

        public void MoveX(int startTime, int endTime, double xi, double xf)
        {
            sb.Append(" MX,0," + startTime + "," + endTime + "," + xi + "," + xf + "\r\n");
        }

        public void MoveX(int easing, int startTime, int endTime, double xi, double xf)
        {
            sb.Append(" MX," + easing + "," + startTime + "," + endTime + "," + xi + "," + xf + "\r\n");
        }

        public void MoveX(int easing, int startTime, int endTime, double xi, double xf, bool Loop)
        {

            if (Loop == true)
                sb.Append("  MX," + easing + "," + startTime + "," + endTime + "," + xi + "," + xf + "\r\n");
            else
                MoveX(easing, startTime, endTime, xi, xf);
        }


        #endregion#

        #region MoveY#

        public void MoveY(int startTime, int endTime, double yi, double yf)
        {
            sb.Append(" MY,0," + startTime + "," + endTime + "," + yi + "," + yf + "\r\n");
        }

        public void MoveY(int easing, int startTime, int endTime, double yi, double yf)
        {
            sb.Append(" MY," + easing + "," + startTime + "," + endTime + "," + yi + "," + yf + "\r\n");
        }

        public void MoveY(int easing, int startTime, int endTime, double yi, double yf, bool Loop)
        {

            if (Loop == true)
                sb.Append("  MY," + easing + "," + startTime + "," + endTime + "," + yi + "," + yf + "\r\n");
            else
                MoveY(easing, startTime, endTime, yi, yf);
        }


        #endregion#

        #region Scale#

        public void Scale(int startTime, double size)
        {
            sb.Append(" S,0," + startTime + ",," + size + "\r\n");
        }

        public void Scale(int startTime, int endTime, double si, double sf)
        {
            sb.Append(" S,0," + startTime + "," + endTime + "," + si + "," + sf + "\r\n");
        }

        public void Scale(int easing, int startTime, int endTime, double si, double sf)
        {
            sb.Append(" S," + easing + "," + startTime + "," + endTime + "," + si + "," + sf + "\r\n");
        }

        public void Scale(int easing, int startTime, int endTime, double si, double sf, bool Loop)
        {

            if (Loop == true)
                sb.Append("  S," + easing + "," + startTime + "," + endTime + "," + si + "," + sf + "\r\n");
            else
                Scale(easing, startTime, endTime, si, sf);
        }


        #endregion#

        #region Fade#

        public void Fade(int startTime, double radians)
        {
            sb.Append(" F,0," + startTime + ",," + radians + "\r\n");
        }

        public void Fade(int startTime, int endTime, double ri, double rf)
        {
            sb.Append(" F,0," + startTime + "," + endTime + "," + ri + "," + rf + "\r\n");
        }

        public void Fade(int easing, int startTime, int endTime, double ri, double rf)
        {
            sb.Append(" F," + easing + "," + startTime + "," + endTime + "," + ri + "," + rf + "\r\n");
        }

        public void Fade(int easing, int startTime, int endTime, double ri, double rf, bool Loop)
        {

            if (Loop == true)
                sb.Append("  F," + easing + "," + startTime + "," + endTime + "," + ri + "," + rf + "\r\n");
            else
                Fade(easing, startTime, endTime, ri, rf);
        }


        #endregion#

        #region Rotate#

        public void Rotate(int startTime, double radians)
        {
            sb.Append(" R,0," + startTime + ",," + radians + "\r\n");
        }

        public void Rotate(int startTime, int endTime, double ri, double rf)
        {
            sb.Append(" R,0," + startTime + "," + endTime + "," + ri + "," + rf + "\r\n");
        }

        public void Rotate(int easing, int startTime, int endTime, double ri, double rf)
        {
            sb.Append(" R," + easing + "," + startTime + "," + endTime + "," + ri + "," + rf + "\r\n");
        }

        public void Rotate(int easing, int startTime, int endTime, double ri, double rf, bool Loop)
        {

            if (Loop == true)
                sb.Append("  R," + easing + "," + startTime + "," + endTime + "," + ri + "," + rf + "\r\n");
            else
                Rotate(easing, startTime, endTime, ri, rf);
        }


        #endregion#

        #region ScaleVec#

        public void ScaleVec(int startTime, double sizex, double sizey)
        {
            sb.Append(" V,0," + startTime + ",," + sizex + "," + sizey + "\r\n");
        }

        public void ScaleVec(int startTime, int endTime, double sxi, double syi, double sxf, double syf)
        {
            sb.Append(" V,0," + startTime + "," + endTime + "," + sxi + "," + syi + "," + sxf + "," + syf + "\r\n");
        }

        public void ScaleVec(int easing, int startTime, int endTime, double sxi, double syi, double sxf, double syf)
        {
            sb.Append(" V," + easing + "," + startTime + "," + endTime + "," + sxi + "," + syi + "," + sxf + "," + syf + "\r\n");
        }


        public void ScaleVec(int easing, int startTime, int endTime, double sxi, double syi, double sxf, double syf, bool Loop)
        {

            if (Loop == true)
                sb.Append(" V," + easing + "," + startTime + "," + endTime + "," + sxi + "," + syi + "," + sxf + "," + syf + "\r\n");
            else
                ScaleVec(easing, startTime, endTime, sxi, syi, sxf, syf);
        }


        #endregion#

        #region Color#

        public void Color(int startTime, int r, int g, int b)
        {
            sb.Append(" C,0," + startTime + ",," + r + "," + g + "," + b + "\r\n");
        }

        public void Color(int startTime, string RGB)
        {
            sb.Append(" C,0," + startTime + ",," + RGB + "\r\n");
        }

        public void Color(int startTime, int endTime, int ri, int gi, int bi, int rf, int gf, int bf)
        {
            sb.Append(" C,0," + startTime + "," + endTime + "," + ri + "," + gi + "," + bi + "," + rf + "," + gf + "," + bf + "\r\n");
        }

        public void Color(int easing, int startTime, int endTime, int ri, int gi, int bi, int rf, int gf, int bf)
        {
            sb.Append(" C," + easing + "," + startTime + "," + endTime + "," + ri + "," + gi + "," + bi + "," + rf + "," + gf + "," + bf + "\r\n");
        }

        public void Color(int easing, int startTime, int endTime, string rgbi, string rgbf)
        {
            sb.Append(" C," + easing + "," + startTime + "," + endTime + "," + rgbi + "," + rgbf + "\r\n");
        }

        public void Color(int easing, int startTime, int endTime, int ri, int gi, int bi, int rf, int gf, int bf, bool Loop)
        {

            if (Loop == true)
                sb.Append("  C," + easing + "," + startTime + "," + endTime + "," + ri + "," + gi + "," + bi + "," + rf + "," + gf + "," + bf + "\r\n");
            else
                Color(easing, startTime, endTime, ri, gi, bi, rf, gf, bf);
        }

        public void Color(int easing, int startTime, int endTime, string rgbi, string rgbf, bool Loop)
        {

            if (Loop == true)
                sb.Append("  C," + easing + "," + startTime + "," + endTime + "," + rgbi + "," + rgbf + "\r\n");
            else
                Color(easing, startTime, endTime, rgbi, rgbf);
        }


        #endregion#

        #region Additive#

        public void Additive(int startTime)
        {
            sb.Append(" P,0," + startTime + ",,A\r\n");
        }

        public void Additive(int easing, int startTime, int endTime)
        {
            sb.Append(" P," + easing + "," + startTime + "," + endTime + ",A\r\n");
        }


        #endregion#

        #region FlipH#

        public void FlipH(int startTime)
        {
            sb.Append(" P,0," + startTime + ",,H\r\n");
        }

        public void FlipH(int easing, int startTime, int endTime)
        {
            sb.Append(" P," + easing + "," + startTime + "," + endTime + ",H\r\n");
        }


        #endregion#

        #region FlipV#

        public void FlipV(int startTime)
        {
            sb.Append(" P,0," + startTime + ",,V\r\n");
        }

        public void FlipV(int easing, int startTime, int endTime)
        {
            sb.Append(" P," + easing + "," + startTime + "," + endTime + ",V\r\n");
        }


        #endregion#

        //Extras

        #region Loops#

        public void Loop(int startTime, int times)
        {
            sb.Append(" L," + startTime + "," + times + "\r\n");
        }

        #endregion#

        #region TriggerLoops#

        public void TriggerLoop(string TriggerLoop)
        {
            sb.Append(" T," + TriggerLoop + "\r\n");
        }

        public void TriggerLoop(string TriggerLoop, int startTime, int endTime)
        {
            sb.Append(" T," + TriggerLoop + "," + startTime + "," + endTime + "\r\n");
        }

        #endregion#


        public string GetOSB()
        {
            return sb.ToString();
        }

    }

}
