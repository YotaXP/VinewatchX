using System;
using System.IO;
using System.Windows.Forms;

namespace VinewatchX.Forms
{
    public partial class AddPrompt : Form
    {
        private string soundfile = "InternalResource";
        private MainForm parentsForm;

        public AddPrompt()
        {
            InitializeComponent();
        }

        public AddPrompt(MainForm reference)
        {
            parentsForm = reference;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog() {
                Filter = "Wav Files|*.wav",
                Title = "Select a Wav File for the new Streamer"
            };

            if (Directory.Exists(Path.Combine(Program.Directory, @"Sample Wavs\")))
                dlg.InitialDirectory = Path.Combine(Program.Directory, @"Sample Wavs\");

            if (dlg.ShowDialog() == DialogResult.OK) {
                this.soundfile = dlg.FileName;
                addPomptCurrentSoundLabel.Text = this.soundfile;
            }
        }

        private void addPromptCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addPromptConfirmButton_Click(object sender, EventArgs e)
        {
            if (addPromptNameTextbox.Text == null || this.soundfile == null)
            {
                MessageBox.Show("You dork, you didn't fill in all the fields!");
            }

            if (soundfile == null || soundfile == "InternalResource")
            {
                if (MessageBox.Show("Soundfile is not set! Use buillt-in sound 'So Much To Do So Much To See' by Smash Mouth?", "No soundfile set!", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    soundfile = "InternalResource";
                }
                else {
                    return;
                }
            }

            StreamerUtils.AddStreamer(addPromptNameTextbox.Text, soundfile);
            this.Close();
        }
    }
}
