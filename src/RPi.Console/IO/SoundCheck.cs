using System;
using System.IO;
using System.Media;
using System.Threading;
using Common.Logging;
using Kraken.Core;

namespace RPi.ConsoleApp.IO
{
    /// <summary>
    /// http://raspberrypi.stackexchange.com/questions/3368/is-there-a-way-to-get-soundplayer-to-work-or-is-there-an-alternative
    /// </summary>
    /// <example>sudo mono rpiconsole.exe -m=SoundTest -nopcm</example>
    class SoundTest
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        private string WavFile 
        {
            get
            {
                var baseDir = AppDomain.CurrentDomain.BaseDirectory;
                var relativePath = string.Format("resources{0}dive.wav", Path.DirectorySeparatorChar);
                var diveWavPath = Path.Combine(baseDir, relativePath);
                return diveWavPath;
            }
        }

        /// <summary>
        /// if run as sudo, the SSH session hangs and eed to start a new one. 
        /// </summary>
        public void PlayWithSoundPlayer()
        {

            //using (var file = new FileStream(WavFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                Log.Info(m => m("SoundPlayer Sync: {0}", WavFile));
                var player = new SoundPlayer();
                player.SoundLocation = WavFile;
                player.PlaySync();
            }
        }

        public void PlayWithSoundPlayerAsync()
        {

            Log.Info(m => m("SoundPlayer Async: {0}", WavFile));
            var player = new SoundPlayer();
            player.SoundLocation = WavFile;
            //player.LoadCompleted += (s, e) => { Log.Info("Load completed, playing");  };
            //player.LoadAsync();
            player.Play();
            Log.Info("done");
            Thread.Sleep(3000);
        }

        private void Player_LoadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void PlayWithAPlay()
        {
            var process = new AplayProcess();
            process.SoundFile = WavFile;
            process.Start();
        }

        /// <summary>
        /// hacky but works on the pi
        /// http://stackoverflow.com/questions/17288985/how-to-make-mono-beep-or-play-sound-under-64-bit-linux
        /// </summary>
        private class AplayProcess : KrakenProcess
        {
            public string SoundFile 
            { 
                get { return Arguments; }
                set { Arguments = value; }
            }

            public AplayProcess()
            {
                FriendlyName = "sound file";
                Filename = Environment.OSVersion.Platform == PlatformID.Unix ? "aplay" : "wmplayer.exe";
            }
        }
    }
}
