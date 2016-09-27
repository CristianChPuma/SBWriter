using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Un4seen.Bass;

namespace Sbter
{
    public class Spectrum
    {

        private int stream, start, end, bpm, bars;
        private string filename;
        /// <summary>
        /// Creates a new spectrum visualizer
        /// </summary>
        /// <param name="filename">Song's filename</param>
        /// <param name="bars">Number of bars to be generated</param>
        public Spectrum(string filename, int bars, int startTime, int endTime, int bpm)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
            this.filename = filename;
            this.bars = bars;
            start = startTime;
            end = endTime;
            this.bpm = bpm;
                BeginStream();
        }

        List<SpectrumData> data = new List<SpectrumData>();

        List<string> values = new List<string>();
        StringBuilder _fft = new StringBuilder();
        List<double> fft_list = new List<double>();
        /// <summary>
        /// Create a file with fft data to avoid slow loading 
        /// </summary>
        public List<SpectrumData> GenerateData()
        {

            for (int position = start; position < end; position += bpm / 4)
            {
                
                Bass.BASS_ChannelSetPosition(stream, Bass.BASS_ChannelSeconds2Bytes(stream, position * 0.001), BASSMode.BASS_POS_BYTES);
                float[] fft = new float[2048];
                Bass.BASS_ChannelGetData(stream, fft, (int)BASSData.BASS_DATA_FFT4096);
                double[] fft_values = new double[bars];
                for (int i = 0; i < bars; i++)
                {
                    fft_values[i]= Math.Round(double.Parse((((fft[i] * 2000 / 40) + 0.1).ToString()).Split('E')[0]),2);
                }

                data.Add(new SpectrumData() {StartTime = position, EndTime = (position + (bpm / 4)), Frecuencies = fft_values });

                _fft.Clear();
            }     

            return data;

        }

       

        private void BeginStream()
        {

            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_UPDATEPERIOD, 0);
            Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_3D, IntPtr.Zero);
            stream = Bass.BASS_StreamCreateFile(filename, 0, 0, BASSFlag.BASS_STREAM_DECODE);
        }




    }

    public class SpectrumData
    {

    public int StartTime { get; set; }
    public int EndTime { get; set; }
    public string FFT { get; set; }
    public double [] Frecuencies { get; set; } 
    public int Line { get; set; }
    public int Bar { get; set; }
    }

}
