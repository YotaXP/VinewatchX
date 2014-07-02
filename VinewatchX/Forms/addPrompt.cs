using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace VinewatchX.Forms
{
    public partial class addPrompt : Form
    {
        private Stream soundfile;
        private MainForm parentsForm;

        public addPrompt()
        {
            InitializeComponent();
        }

        public addPrompt(MainForm reference)
        {
            parentsForm = reference;
            InitializeComponent();
        }

        private void addPrompt_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Wav Files|*.wav";
            openFileDialog1.Title = "Select a Wav File for the new Streamer";

            if (Directory.Exists(@"C:\Program Files (x86)\VinewatchX\Sample Wavs"))
                openFileDialog1.InitialDirectory = @"C:\Program Files (x86)\VinewatchX\Sample Wavs";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.soundfile = File.Open(openFileDialog1.FileName, FileMode.Open);
            }
            if (soundfile != null)
                addPomptCurrentSoundLabel.Text = this.soundfile.ToString();
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

            if (this.soundfile == null)
            {
                if (MessageBox.Show("Soundfile is not set! Use buillt-in sound 'Fuck You' by Van Darkholme?", "No soundfile set!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    parentsForm.addStreamer(addPromptNameTextbox.Text, Properties.Resources.notify_smtdsmts);
                    this.Close();
                }
              
            }

            parentsForm.addStreamer(addPromptNameTextbox.Text, this.soundfile);
            this.Close();

        }
    }
}
