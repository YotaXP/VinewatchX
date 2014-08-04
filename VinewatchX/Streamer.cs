using System;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace VinewatchX
{
    ///<summary>
    /// Object to represent configurations unique to a streamer (Soundfile to play and name).
    ///</summary>
    public class Streamer
    {
        private string name;
        private string soundfileName;
        private Stream soundfile;

        private SoundPlayer refreshSound()
        {
            SoundPlayer snd = new SoundPlayer(this.soundfile);
            snd.Stream.Position = 0;
            return snd;
        }

        public Streamer(String tname)
        {
            this.name = tname;
            this.soundfile = Properties.Resources.notify_smtdsmts;   //Default Notification
            soundfileName = "InternalResource";
        }

        public Streamer(String tname, Stream tsoundfile)
        {
            this.name = tname;
            this.soundfile = tsoundfile;
            soundfileName = "InternalResource";
        }

        public Streamer(String tname, string dirToSoundfile)
        {
            try
            {
                this.name = tname;
                this.soundfile = File.Open(dirToSoundfile, FileMode.Open);
                soundfileName = dirToSoundfile;
            }
            catch (IOException)
            {
                MessageBox.Show(this.name + "'s soundfile - " + "File specificed is in use, maybe (IOException)\nVinewatchX will try to use it regardless, and will probably succeed.");
            }

        }

        public string getName()
        {
            return this.name;
        }

        public Stream getSoundfile()
        {
            return this.soundfile;
        }

        public string getSoundfileName()
        {
            return this.soundfileName;
        }

        public void setName(string tname)
        {
            this.name = tname;
        }

        public void setSoundfile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Wav Files|*.wav";
            openFileDialog1.Title = "Select a Wav File for streamer: " + this.getName();

            if (Directory.Exists(@"C:\Program Files (x86)\VinewatchX\Sample Wavs"))
                openFileDialog1.InitialDirectory = @"C:\Program Files (x86)\VinewatchX\Sample Wavs";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.soundfile = File.Open(openFileDialog1.FileName, FileMode.Open);
                this.soundfileName = openFileDialog1.FileName;
            }
        }

        public void playSound()
        {
            this.refreshSound().Play();
        }

        /// <summary>
        /// Used to create configurations. Determines internal or external soundfiles.
        /// </summary>
        /// <returns>An appropriate name for the soundfile should it be external, else "InternalResource" for internal.</returns>
        internal string getSoundfileAsString()
        {
            if (soundfile.ToString() == "System.IO.UnmanagedMemoryStream" || soundfile == null)
            {
                return "InternalResource";
            }

            return soundfileName;
        }
    }
}
