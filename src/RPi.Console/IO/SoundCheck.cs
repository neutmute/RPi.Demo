using System;
using System.IO;
using System.Media;
using Common.Logging;

namespace RPi.ConsoleApp.IO
{
    /// <summary>
    /// http://raspberrypi.stackexchange.com/questions/3368/is-there-a-way-to-get-soundplayer-to-work-or-is-there-an-alternative
    /// </summary>
    /// <example>sudo mono rpiconsole.exe -m=SoundTest -nopcm</example>
    class SoundTest
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        public void Play()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var diveWavPath = Path.Combine(baseDir, "resources/dive.wav");
            using (var file = new FileStream(diveWavPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                Log.Info(m => m("Playing {0}", diveWavPath));
                var player = new SoundPlayer(file);
                player.PlaySync();
                Log.Info("done");
            }
        }
    }
}
