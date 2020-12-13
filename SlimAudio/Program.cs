using NAudio.Wave;
using System;
using System.Threading;

namespace SlimAudio
{
    class Program
    {

        static void Main(string[] args)
        {
            if (args.Length == 0)
                Console.WriteLine("slim audio player - written by joshMS. usage: slim.exe <file>");

            if (args.Length == 0)
                return;



            Console.Write($"Playing {args[0]}");
            int tics = 0;
            using (var audioFile = new AudioFileReader(args[0]))
            {
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(10);
                        tics += 10;
                        if (tics % 100 == 0)
                            Console.Write(".");
                    }
                        
                }
            }
            Console.Write($"  Done! ({tics/1000.0f})s");
            Console.WriteLine();

        }
    }
}
