using System;
using System.IO;
using System.Media;
using System.Text.RegularExpressions;
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
                Forms.OmniPlayer.Stop();
            }
        }

        public void PlaySound() {
            try {

                    if (SoundFilename == "InternalResource")
                    {
                        Forms.OmniPlayer.Play("Samples/notify_smtdsmts.mp3");
                    }
                    else
                    {
                        Forms.OmniPlayer.Play(SoundFilename);
                    }

            }
            catch (System.IO.FileNotFoundException) { }
            catch (InvalidOperationException) { }
        }

        public int CompareTo(Streamer other) {
            return Name.CompareTo(other.Name);
        }

        public override string ToString() {
            return Name;
        }
    }
}
