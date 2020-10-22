using AudioSwitcher;
using AudioSwitcher.AudioApi.CoreAudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicUnmute
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Microphone un-muter by P Dring");
            Console.WriteLine("This program will detect and unmute all microphones / webcams");
            Console.WriteLine("Detecting microphones...");
            CoreAudioController controller = new CoreAudioController();
            foreach (CoreAudioDevice device in controller.GetCaptureDevices())
            {
                Console.Write("  > Detected: " + device.FullName + ": ");
                if(device.IsMuted)
                {
                    Console.Write("Muted - attempting to unmute");
                    device.Mute(false);
                    if(device.IsMuted)
                    {
                        Console.Write(" failed :(");
                    } else
                    {
                        Console.Write(" success :)");
                    }
                } else
                {
                    Console.Write("Unmuted");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Done - press enter to close this window");
            Console.ReadLine();
        }
    }
}
