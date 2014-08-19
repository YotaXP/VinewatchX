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
                Filter = "Wav/Mp3 Files|*.wav;*.mp3",
                Title = "Select a Wav/Mp3 File for the new Streamer"
            };

            if (Directory.Exists(Path.Combine(Program.Directory, @"Samples\")))
                dlg.InitialDirectory = Path.Combine(Program.Directory, @"Samples\");

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
            if (addPromptNameTextbox.Text == null)
            {
                MessageBox.Show("You dork, you didn't fill the name field!");
                return;
            }

            if (soundfile == null)
                soundfile = "InternalResource";


            StreamerUtils.AddStreamer(addPromptNameTextbox.Text, soundfile);
            this.Close();
        }
    }
}
