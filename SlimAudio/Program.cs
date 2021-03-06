﻿
using NAudio.Wave;
using System;
using System.Threading;

namespace SlimAudio
{

    class Program
    {
	static string GreetingText = @"
slim audio player - by josholeary. usage: slim.exe [args] <file>
supported filetypes: .wav, .mp3, .ogg should all work, i dunno about .flac
arguments:
	-v --volume 0-100
	-r --repeat repeatCount
	-s --silent (No terminal output)


questions and bugs can be sent to me at the address below

Generally, playing sound files is a hassle. As a game developer, I find myself often 
repeatedly listening to and modifying short audio clips. Booting up Windows
Media Player or whatever the fuck every 0.3 seconds gets annoying fast. So I created
a small, simple, and fast program to replay soundfiles via command line.

Use the code for your own shit, at your own risk. I'm not buying you a new subwoofer if
you nuke it by accident lol.

conarium.xyz
contact:> josh@mail.conarium.xyz
";
        static void Main(string[] args)
        {
            if (args.Length == 0)
                Console.WriteLine(GreetingText);

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
                        tics ++;
			if (tics%0==50)
                        	Console.Write(".");
                    }
                        
                }
            }
            Console.Write($"  Done! ({tics/100.0f})s");
            Console.WriteLine();

        }
    }
}
