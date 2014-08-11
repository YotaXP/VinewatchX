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
        public string SoundFilename { get; private set; }
        private SoundPlayer player;

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
                Filter = "Wav Files|*.wav",
                Title = "Select a Wav File for streamer: " + Name
            };

            if (Directory.Exists(Path.Combine(Program.Directory, @"Sample Wavs\")))
                dlg.InitialDirectory = Path.Combine(Program.Directory, @"Sample Wavs\");

            if (dlg.ShowDialog() == DialogResult.OK) {
                this.SoundFilename = dlg.FileName;
                if (player != null) {
                    player.Dispose();
                    player = null;
                }
            }
        }

        public void PlaySound() {
            try {
                if (player == null) {
                    if (SoundFilename == "InternalResource")
                        player = new SoundPlayer(Properties.Resources.notify_smtdsmts);
                    else
                        player = new SoundPlayer(SoundFilename);
                }
                player.Play();
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
