using System;
using System.IO;
using System.Media;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace VinewatchX
{
    ///<summary>
    /// Object to represent configurations unique to a streamer (Soundfile to play and name).
    ///</summary>
    public class Streamer : IComparable<Streamer>
    {
        public string SoundFilename { get; set; }

        private string _name;
        public string Name {
            get { return _name; }
            set { _name = Regex.Replace(value, @"[\x00-\x1F]", ""); } // Keep things sanitary!
        }

        public string Aliases = "";
        public string AltService = "";
        public string AltChannel = "";
        public bool MonitorAltChannel = false;

        public Streamer(string streamerName, string soundFilename = "InternalResource") {
            Name = streamerName;
            SoundFilename = soundFilename;
        }

        public void ShowSoundFileSelectDialog() {
            OpenFileDialog dlg = new OpenFileDialog() {
                Filter = "Wav/Mp3 Files|*.wav;*.mp3",
                Title = "Select a Wav/Mp3 File for streamer: " + Name
            };

            if (Directory.Exists(Path.Combine(Program.Directory, @"Samples\")))
                dlg.InitialDirectory = Path.Combine(Program.Directory, @"Samples\");

            if (dlg.ShowDialog() == DialogResult.OK) {
                this.SoundFilename = dlg.FileName;
                //Forms.OmniPlayer.Stop();
            }
        }
        
        public void PlaySound() {
            try {

                // this shitty method of calling the play method between thread might now be
                // an optimal way to do it. I tried to do it with delegates but it doesn't seem to work...

                    if (SoundFilename == "InternalResource")
                    {
                        Forms.MainForm.mf.SoundToPlay = "Samples/notify_smtdsmts.mp3";
                        //OmniPlayer.Play("Samples/notify_smtdsmts.mp3");
                    }
                    else
                    {
                        Forms.MainForm.mf.SoundToPlay = SoundFilename;
                        //OmniPlayer.Play(SoundFilename);
                    }

            }
            catch (System.IO.FileNotFoundException) 
            {
                new object();
            }
            catch (InvalidOperationException) 
            {
                new object();
            }

        }

        public int CompareTo(Streamer other) {
            return Name.CompareTo(other.Name);
        }

        public override string ToString() {
            return Name;
        }
    }
}
