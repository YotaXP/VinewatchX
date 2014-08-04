using System;
using System.Windows.Forms;

namespace VinewatchX.Forms
{
    public partial class EditPrompt : Form
    {
        public Streamer targetStreamer = null;
        public MainForm ParentForms = null;

        public EditPrompt()
        {
            this.Text = "Editing " + targetStreamer.getName();
            this.editPromptInfoLabel.Text = "new Name for streamer " + targetStreamer.getName();
            InitializeComponent();
        }

        public EditPrompt(MainForm reference, Streamer target)
        {
            ParentForms = reference;
            targetStreamer = target;

            this.Text = "Editing Streamer " + targetStreamer.getName();
            InitializeComponent();
        }

        private void editPrompt_Load(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            ParentForms.editStreamerName(targetStreamer, newNameTextBox.Text);
            this.Close();
        }
    }
}
