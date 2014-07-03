﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace VinewatchX.Forms
{
    public partial class OptionsForm : Form
    {
        MainForm parentForm;





        public OptionsForm(MainForm reference)
        {
            parentForm = reference;

            InitializeComponent();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            streamCheckURLLabel.Text = parentForm.getStreamURL();
            streamCheckPollRateLabel.Text = parentForm.getStreamPollRate();
            balloonTipTimeoutlabel.Text = parentForm.getBalloonTipTimeout();

            refreshIconPictureBox();

            listBoxPopulate();
        }

        





        private void listBoxPopulate()
        {
            List<String> T = parentForm.getStreamerListAsStringList();
            foreach (String s in T){
                Debug.Write(" + " + s);
            } Debug.WriteLine("");

            optionsFormStreamerListBox.DataSource = parentForm.getStreamerListAsStringList();
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
                    string selectedStreamerName = optionsFormStreamerListBox.Items[(int)selectedIndex].ToString();
                    parentForm.editStreamerSound(selectedStreamerName);
                }
                catch
                {
                    Debug.WriteLine("!!!\n  OptionsForm.cs - streamerListBoxInteractButton_Click\n\ttry has failed!");
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
                    string selectedStreamerName = optionsFormStreamerListBox.Items[(int)selectedIndex].ToString();
                    parentForm.playStreamerSound(selectedStreamerName);
                }
                catch
                {
                    Debug.WriteLine("!!!\n  OptionsForm.cs - streamerListPlayButton_Click\n\ttry has failed!");
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
                    string selectedStreamerName = optionsFormStreamerListBox.Items[(int)selectedIndex].ToString();
                    selectionInfoLabel.Text = ("Streamer: " + selectedStreamerName);
                }
                catch
                {
                    Debug.WriteLine("!!!\n  OptionsForm.cs - optionsFormStreamerListBox_SelectedIndexChanged\n\ttry has failed! selectedIndex = " + selectedIndex);
                }
            }
        }

        private void streamerListDeleteButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = optionsFormStreamerListBox.SelectedIndex;

            string selectedStreamerName = optionsFormStreamerListBox.Items[selectedIndex].ToString();

            if (MessageBox.Show("Really delete " + selectedStreamerName + "?", "Confirm delete: " + selectedStreamerName, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                parentForm.deleteStreamerByName(selectedStreamerName);
                listBoxRePopulate();
            }
        }

        private void streamerListChangeNameButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = optionsFormStreamerListBox.SelectedIndex;

            string selectedStreamerName = optionsFormStreamerListBox.Items[selectedIndex].ToString();

            editPrompt f = new editPrompt(parentForm, parentForm.getStreamer(selectedStreamerName));
            f.Show();
        }

        private void streamerListRefreshButton_Click(object sender, EventArgs e)
        {
            listBoxRePopulate();
        }

        private void streamerListAddButton_Click(object sender, EventArgs e)
        {
            addPrompt f = new addPrompt(parentForm);
            f.Show();
        }

        private void changePollURLButton_Click(object sender, EventArgs e)
        {
            string promptValue = Prompt.ShowDialog("This is the URL that the poller will check.", "Set new Poll URL");
            parentForm.setPollerURl(promptValue);
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

            streamCheckPollRateLabel.Text = parentForm.getStreamPollRate();
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
            parentForm.applyIcons();

            VineConf conf = new VineConf(parentForm);
            conf.exportConfig(Directory.GetCurrentDirectory());
            MessageBox.Show("Config saved to " + Directory.GetCurrentDirectory() + @"vinewatchXConfig.txt");
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
            Label textLabel = new Label() { Left = 2, Top = 12, Width=200, Text = text };
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
}