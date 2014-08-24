using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Speech.Synthesis;
using System.Threading;
using System.Windows.Forms;

namespace VinewatchX.Forms
{
    public partial class OptionsForm : Form
    {
        MainForm parentForm;
        bool NoSave = false;

        public OptionsForm()
        {

            InitializeComponent();
            runVinewatchStartupCheckbox.AutoCheck = false;
        }

        public OptionsForm(bool show)
        {

            InitializeComponent();
            runVinewatchStartupCheckbox.AutoCheck = false;

            if (show)
                this.Show();
                
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            parentForm = MainForm.mf;

            streamCheckPollRateLabel.Text = parentForm.getPollRate();
            balloonTipTimeoutlabel.Text = parentForm.getBalloonTipTimeout();

            refreshIconPictureBox();

            listBoxPopulate();
        }

        private void listBoxPopulate()
        {
            optionsFormStreamerListBox.DataSource = StreamerUtils.StreamerList.ToList();
            optionsFormStreamerListBox.DisplayMember = "Name";
        }

        private void listBoxRePopulate()
        {
            optionsFormStreamerListBox.DataSource = null;
            listBoxPopulate();
        }

        private void streamerListBoxInteractButton_Click(object sender, EventArgs e)
        {
            int? selectedIndex = optionsFormStreamerListBox.SelectedIndex;

            if (selectedIndex != -1)
            {
                try
                {
                    var s = optionsFormStreamerListBox.SelectedItem as Streamer;
                    if (s != null) s.ShowSoundFileSelectDialog();
                }
                catch
                {
                    xDebug.WriteLine("!!!\n  OptionsForm.cs - streamerListBoxInteractButton_Click\n\ttry has failed!");
                }
            }
        }

        private void streamerListPlayButton_Click(object sender, EventArgs e)
        {
            int? selectedIndex = optionsFormStreamerListBox.SelectedIndex;
            if (selectedIndex != -1)
            {
                try
                {
                    var s = optionsFormStreamerListBox.SelectedItem as Streamer;
                    if (s != null) s.PlaySound();
                }
                catch
                {
                    xDebug.WriteLine("!!!\n  OptionsForm.cs - streamerListPlayButton_Click\n\ttry has failed!");
                }
            }
        }

        private void optionsFormStreamerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int? selectedIndex = optionsFormStreamerListBox.SelectedIndex;
            if (selectedIndex != -1)
            {
                try
                {
                    var s = optionsFormStreamerListBox.SelectedItem as Streamer;
                    if (s != null)
                    { 
                        selectionInfoLabel.Text = ("Streamer: " + s.Name);

                        streamerAliasesTextbox.Text = s.Aliases;
                        altChannelNameTextbox.Text = s.AltChannel;
                        altChannelServiceCombobox.Text = s.AltService;
                        monitorAltChannelCheckbox.Checked = s.MonitorAltChannel;
                    }
                }
                catch
                {
                    xDebug.WriteLine("!!!\n  OptionsForm.cs - optionsFormStreamerListBox_SelectedIndexChanged\n\ttry has failed! selectedIndex = " + selectedIndex);
                }
            }
        }

        private void streamerListDeleteButton_Click(object sender, EventArgs e)
        {
            var s = optionsFormStreamerListBox.SelectedItem as Streamer;
            if (s != null && MessageBox.Show("Really delete " + s.Name + "?", "Confirm delete: " + s.Name, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                StreamerUtils.StreamerList.Remove(s);
                listBoxRePopulate();
            }
        }

        private void streamerListChangeNameButton_Click(object sender, EventArgs e)
        {
            var s = optionsFormStreamerListBox.SelectedItem as Streamer;
            if (s != null) {
                new EditPrompt(parentForm, s).ShowDialog();
                listBoxRePopulate();
            }
        }

        private void streamerListAddButton_Click(object sender, EventArgs e)
        {
            new AddPrompt(parentForm).ShowDialog();
            listBoxRePopulate();
        }

        private void changePollRateButton_Click(object sender, EventArgs e)
        {
            string promptValue = Prompt.ShowDialog("This is the timout between poll checks", "Set new Poll Rate");

            int numVal = 30;

            try
            {
                numVal = Int32.Parse(promptValue);
            }
            catch (FormatException)
            {
                MessageBox.Show("Input string is not a sequence of digits.\n");
            }
            catch (OverflowException)
            {
                MessageBox.Show("The number cannot fit in an Int32.\n");
            }
            finally
            {
                if (numVal < Int32.MaxValue)
                {
                    if (numVal < 6001 && numVal > 15)
                    {
                        MessageBox.Show("The new value is " + (numVal));
                        parentForm.setPollRate(numVal);
                    }
                    else
                    {
                        MessageBox.Show("Value must be less than 6001 and greater than 15.");
                    }
                }
                else
                {
                    MessageBox.Show("numVal cannot be incremented beyond its current value");
                }
            }

            streamCheckPollRateLabel.Text = parentForm.getPollRate();
        }

        private void changeBalloonTipTimeoutButton_Click(object sender, EventArgs e)
        {
            string promptValue = Prompt.ShowDialog("This is the remnance of the baloon tip", "Set new Poll Rate");

            int numVal = 3;

            try
            {
                numVal = Int32.Parse(promptValue);
            }
            catch (FormatException)
            {
                MessageBox.Show("Input string is not a sequence of digits.\n");
            }
            catch (OverflowException)
            {
                MessageBox.Show("The number cannot fit in an Int32.\n");
            }
            finally
            {
                if (numVal < Int32.MaxValue)
                {
                    parentForm.setBalloonTipTimeout(numVal);
                }
                else
                {
                    MessageBox.Show("numVal cannot be incremented beyond its current value");
                }
            }

            balloonTipTimeoutlabel.Text = parentForm.getBalloonTipTimeout();
        }

        private void refreshIconPictureBox()
        {
            this.iconDisplayPictureBox.Image = Bitmap.FromHicon(new Icon(parentForm.Icon, new Size(48, 48)).Handle);
        }

        private void OptionsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!NoSave)
            { 
                VineConf conf = new VineConf(parentForm);
                conf.exportConfig(Directory.GetCurrentDirectory());
            }
        }

        private void changeIconButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Icon Files|*.ico";
            openFileDialog1.Title = "Select a new VinewatchX icon";

            if (Directory.Exists(@"C:\Program Files (x86)\VinewatchX\"))
                openFileDialog1.InitialDirectory = @"C:\Program Files (x86)\VinewatchX\";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                parentForm.IconDescriptor = openFileDialog1.FileName;
                parentForm.setIcons(new Icon(openFileDialog1.FileName));
            }

            parentForm.applyIcons();
            this.refreshIconPictureBox();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(easterEgg)).Start();
        }

        private void easterEgg()
        {
            Leatherhead l = new Leatherhead();
            l.play();

        }

        private void importSettingsButton_Click(object sender, EventArgs e)
        {
            VineConf conf = new VineConf(parentForm);
            conf.importConfig();
        }

        private void exportSettingsButton_Click(object sender, EventArgs e)
        {
            VineConf conf = new VineConf(parentForm);
            conf.exportConfig2();
        }

        private void notifyTestButton_Click(object sender, EventArgs e)
        {
            parentForm.notifyTest("Guest : This is a test of the notification system.");
        }

        private void runVinewatchStartupCheckbox_Click(object sender, EventArgs e)
        {
            parentForm.startWithWindowsToolStripMenuItem_Click(sender, e);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void resetDefaultSoundButton_Click(object sender, EventArgs e)
        {
            try
            {
                var s = optionsFormStreamerListBox.SelectedItem as Streamer;
                s.SoundFilename = "InternalResource";
            }
            catch
            {
                xDebug.WriteLine("!!!\n  OptionsForm.cs - resetDefaultSoundButton_Click\n\ttry has failed!");
            }
        }

        public void resetToDefaultConfigButton_Click(object sender, EventArgs e)
        {
            resetToDefaultConfigButton_Click(sender, e, true);
            okButton_Click(sender, e);
        }


        public bool resetToDefaultConfigButton_Click(object sender, EventArgs e, bool configAlreadyLoaded)
        {
            VineConf conf = new VineConf(parentForm);
            if (!conf.writeDefaultConfig(configAlreadyLoaded))
                return false;

            if (configAlreadyLoaded)
            {
                NoSave = true;
                MessageBox.Show("Please restart VinewatchX");
                parentForm.exitVinewatchXToolStripMenuItem_Click(new object(), new EventArgs());
                return true;
            }
            return true;
        }

        private void saveStreamerParametersButton_Click(object sender, EventArgs e)
        {
            var s = optionsFormStreamerListBox.SelectedItem as Streamer;
            s.Aliases = streamerAliasesTextbox.Text;
            s.AltChannel = altChannelNameTextbox.Text;
            s.AltService = altChannelServiceCombobox.Text;
            s.MonitorAltChannel = monitorAltChannelCheckbox.Checked;
            
        }

        private void OptionsForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                parentForm.formThreadWatcher.Interval = 50;
            else
                parentForm.formThreadWatcher.Interval = 2000;
        }

        private void showDebugButton_Click(object sender, EventArgs e)
        {
            xDebug.x.Show();
        }

        private void forceUpdateButton_Click(object sender, EventArgs e)
        {
            parentForm.updateButton_Click(sender, e);
        }

    }

    static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form();
            prompt.Icon = Properties.Resources.vs;
            prompt.TopMost = true;
            prompt.StartPosition = FormStartPosition.CenterScreen;
            prompt.Width = 260;
            prompt.Height = 120;
            prompt.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 2, Top = 12, Width = 200, Text = text };
            TextBox textBox = new TextBox() { Left = 2, Top = 35, Width = 200 };
            Button confirmation = new Button() { Text = "Ok", Left = 2, Width = 100, Top = 58 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.ShowDialog();
            return textBox.Text;
        }
    }

    class Leatherhead
    {
        List<String> botg = new List<string>();

        public Leatherhead()
        {
            botg.Add("<prosody pitch=\"x-low\" rate=\"-10%\" volume=\"100\">Hey buddy, I think you've got the wrong door, the leather club is two blocks down.</prosody>");
            botg.Add("<prosody pitch=\"x-high\" rate=\"-100%\" volume=\"100\">Fuck you.</prosody>");
            botg.Add("<prosody pitch=\"x-low\" rate=\"-10%\" volume=\"100\">No, fuck, you! leather man! Maybe you and I should settle it right here on the ring, if you think your so tough?</prosody>");
            botg.Add("<prosody pitch=\"x-high\" rate=\"-10%\" volume=\"100\">Oh yeah?</prosody>");
            botg.Add("<prosody pitch=\"x-low\" rate=\"-10%\" volume=\"100\">Yeah.</prosody>");
            botg.Add("<prosody pitch=\"x-high\" rate=\"-10%\" volume=\"100\">Yeah, I'm gonna wrestle your ass!</prosody>");
            botg.Add("<prosody pitch=\"x-low\" rate=\"-10%\" volume=\"100\">Ha! Yeah right man. Let's go! Why don't you get out of that leather stuff? I'll strip down out of this and we'll settle it right here in the ring. What do you say?</prosody>");
            botg.Add("<prosody pitch=\"x-high\" rate=\"-10%\" volume=\"100\">Yeah, no problem!</prosody>");
            botg.Add("<prosody pitch=\"x-low\" rate=\"-10%\" volume=\"100\">You got it. Get out of that, uh, cha bro neee outfit.</prosody>");
            botg.Add("<prosody pitch=\"x-high\" rate=\"-10%\" volume=\"100\">Yeah, smart ass.</prosody>");
            botg.Add("<prosody pitch=\"x-low\" rate=\"-10%\" volume=\"100\">I'll show you who's the boss of this gym.</prosody>");
        }

        public void play()
        {
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {
                PromptBuilder pb = new PromptBuilder();

                foreach (string line in botg)
                {
                    pb.ClearContent();
                    pb.AppendSsmlMarkup(line);
                    synth.Speak(pb);
                }
            }
        }
    }
}
