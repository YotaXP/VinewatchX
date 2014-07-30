using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Speech.Synthesis;
using System.Threading;
using System.Windows.Forms;

namespace VinewatchX.Forms
{
    public partial class MainForm : Form
    {
        internal const string gVer = "v1.8_X";
        internal const string gVersion = "VinewatchX " + gVer;
        internal string IconDescriptor = "InternalResource";
        internal Icon notificationIconIcon = Properties.Resources.vs;
        internal VinewatchLogic thread0;    // Checking live statuses is handled by VinewatchLogic objects

        protected static bool gX = false;   // Control boolean for an easter-egg
        protected int balloonTipTimeout = 3;
        protected static StreamerUtils con = new StreamerUtils();
        protected Icon currentIcon = Properties.Resources.vs;

        #region Mainform constructor and start-up methods

        internal MainForm(bool tStartMinimized)
        {
            InitializeComponent();

            MainFormPrep();

            if (tStartMinimized) WindowState = FormWindowState.Minimized;
        }

        protected void MainForm_Load(object sender, EventArgs e)
        {
            versionLabel.Text = gVersion;

            //Apply Icons
            applyIcons();

            startThreading();
            createTooltips();
        }

        protected void MainFormPrep()
        {
            thread0 = new VinewatchLogic(this);

            notificationIcon.BalloonTipClicked += new EventHandler(notificationIcon_BalloonTipClicked);

            //Import local config
            try
            {
                VineConf conf = new VineConf(this);
                conf.bypassPromptsImportConfig(Directory.GetCurrentDirectory());
            }
            catch
            {
                MessageBox.Show("Error loading the local config. Populating the Streamer database with the default entries.\n\n" +
                    "EXPORT YOUR CONFIG BEFORE CLOSING!");
                con.populate();
            }

            con.sortAndPruneStreamerList();
        }

        protected void createTooltips()
        {
            ToolTip muteToolTip = new ToolTip(); muteToolTip.SetToolTip(muteRadioButton, "Checked to mute. Unchecked to what are you, a child?");
            ToolTip supressionToolTip = new ToolTip(); supressionToolTip.SetToolTip(supressionRadioButton, "When checked, disables warnings of failed updates. The poller still retries.");
            ToolTip lastReportLabelToolTip = new ToolTip(); lastReportLabelToolTip.SetToolTip(lastReportLabel, "Last report from the TwitchTV feed");
            // CREATE SOME TOOLTIPS FAGGOT
        }

        protected void startThreading()
        {
            Thread t = new Thread(() => thread0.init());
            t.IsBackground = true;
            t.Name = "Main thread.";
            t.Start();
            Debug.WriteLine("Form1.cs\t\tThreading Started");
        }

        #endregion

        #region Notification methods

        internal void notify(string streamTitle)
        {
            playNotifySound(streamTitle);

            notifyX(streamTitle);   // I forgot why I did this.

            setNotificationIconBalloonText(streamTitle.Length > 63 ? streamTitle.Substring(0, 63) : streamTitle);

            showBalloonTip(balloonTipTimeout);
        }

        internal void notifyTest(string streamTitle)
        {
            playNotifySound(streamTitle);

            //Record previous text
            string oldNotificationIconText = notificationIcon.Text;

            setNotificationIconBalloonText(streamTitle.Length > 63 ? streamTitle.Substring(0, 63) : streamTitle);

            showBalloonTip(balloonTipTimeout);

            //Re-apply old text
            setNotificationIconBalloonText(oldNotificationIconText);
        }

        /// <summary>
        /// Performs the actions of notify() without showing the balloon tip or playing the sound.
        /// </summary>
        /// <param name="streamTitle">JSON extract for stream title</param>
        internal void notifyX(string streamTitle)
        {
            setNotificationLabelText(streamTitle);
            setLastReportLabel(streamTitle);
        }

        protected void playNotifySound(string streamTitle)
        {
            if (muteRadioButton.Checked != true)
            {
                if (ttsRadioButton.Checked)
                {
                    new Thread(new ThreadStart(() => playTTS("Vine sauce is Live. " + streamTitle))).Start();
                }
                else
                {
                    con.findAndPlayStreamerSound(streamTitle);
                }
            }
        }

        /// <summary>
        /// Plays SAPI5 Text-to-Speech of the given string
        /// </summary>
        /// <param name="phrase">String to be spoken by the TTS engine</param>
        protected void playTTS(string phrase)
        {
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {
                try
                {
                    synth.SetOutputToDefaultAudioDevice();
                    synth.Speak(phrase);
                }
                catch (Exception)
                {
                    MessageBox.Show("An error has occured when asking your system to use TTS.", "Error");
                }

            }
        }

        internal void setNotificationLabelText(string s)
        {
            if (s.Length > 63)
            {
                notificationIcon.Text = s.Substring(0, 63);
            }
            else
            {
                notificationIcon.Text = s;
            }
        }

        internal void setLastReportLabel(string s)
        {
            if (lastReportLabel.InvokeRequired)
            {
                lastReportLabel.Invoke(new Action(() => lastReportLabel.Text = s));
            }
            else
            {
                lastReportLabel.Text = s;
            }
        }

        #endregion

        #region BalloonTip methods

        protected void setNotificationIconBalloonText(string newValue)
        {
            notificationIcon.Text = newValue;
            notificationIcon.BalloonTipText = newValue;
        }

        protected void showBalloonTip(int timeout)
        {
            notificationIcon.BalloonTipTitle = "Vinewatch X";
            notificationIcon.ShowBalloonTip(timeout);
        }

        internal void setBalloonTipTimeout(int timeout)
        {
            if (timeout > 20 || timeout < 3)
            {
                MessageBox.Show("Invalid - must be between 3 and 20 seconds (Default 3)");
                setBalloonTipTimeout(3);
            }
            else
            {
                balloonTipTimeout = timeout;
            }
        }

        internal string getBalloonTipTimeout()
        {
            return balloonTipTimeout.ToString();
        }

        #endregion

        #region OptionsForm methods

        protected void button1_Click(object sender, EventArgs e)
        {
            OptionsForm opt = new OptionsForm(this);

            opt.Show();
        }

        internal List<string> getStreamerListAsStringList()
        {
            List<string> rtn = new List<string>();
            List<Streamer> src = con.getStreamerList();

            foreach (Streamer eachStreamer in src)
            {
                rtn.Add(eachStreamer.getName());
            }

            return rtn;
        }

        internal void editStreamerName(Streamer target, string newStreamerName)
        {
            con.editStreamerName(target, newStreamerName);
        }

        internal void editStreamerSound(string selectedStreamerName)
        {
            con.editStreamerSoundfile(selectedStreamerName);
        }

        internal void playStreamerSound(string selectedStreamerName)
        {
            con.findAndPlayStreamerSound(selectedStreamerName);
        }

        internal void deleteStreamerByName(string selectedStreamerName)
        {
            con.removeStreamer(selectedStreamerName);
        }

        internal List<Streamer> getStreamerList()
        {
            return con.getStreamerList();
        }

        internal Streamer getStreamer(string selectedStreamerName)
        {
            return con.getStreamerByName(selectedStreamerName);
        }

        internal void addStreamer(string newStreamerName, Stream newSoundFile)
        {
            con.addStreamer(newStreamerName, newSoundFile);
        }

        internal void addStreamer(string newStreamerName, string newSoundFile)
        {
            if (newSoundFile.Equals("InternalResource"))
            {
                con.addStreamer(newStreamerName, Properties.Resources.notify_smtdsmts);
            }
            else
            {
                con.addStreamer(newStreamerName, newSoundFile);
            }
        }

        internal string getStreamURL()
        {
            return thread0.getTwitchTVStreamURL();
        }

        internal string getStreamPollRate()
        {
            return thread0.getPollRate().ToString();
        }

        internal void setPollerURL(string newPollURL)
        {
            thread0.setTwitchTVStreamURL(newPollURL);
        }

        internal void setPollRate(int newPollRate)
        {
            thread0.setPollRate(newPollRate);
        }

        internal void applyIcons()
        {
            this.Icon = currentIcon;

            this.notificationIcon.Icon = notificationIconIcon;
        }

        internal void setIcons(Icon n)
        {
            currentIcon = n;
            //notificationIconIcon = (Icon)n.Clone();
            notificationIconIcon = Properties.Resources.vw;
        }

        internal string getIconsAsString()
        {
            if (currentIcon == Properties.Resources.vs || currentIcon == Properties.Resources.vw)
            {
                return "InternalResource";
            }
            else
            {
                return IconDescriptor;
            }
        }

        internal void setIconsFromString(string p)
        {
            if (p.Equals("InternalResource"))
            {
                setIcons(Properties.Resources.vs);
                applyIcons();
            }
            else
            {
                if (File.Exists(p))
                {
                    setIcons(new Icon(p));
                    applyIcons();
                }
                else
                {
                    notifyX("Icon set in config missing! Default set.");
                    setIcons(Properties.Resources.vs);
                    applyIcons();
                }
            }
        }

        #endregion

        #region Export/Import settings methods

        protected void exportSettingsButton_Click(object sender, EventArgs e)
        {

            VineConf conf = new VineConf(this);
            conf.exportConfig2();
        }

        protected void importSettingsButton_Click(object sender, EventArgs e)
        {
            VineConf conf = new VineConf(this);
            conf.importConfig();

            con.sortAndPruneStreamerList();
        }

        #endregion

        #region Hyperlinks (LinkLabels)

        protected void pictureBoxArt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://vinesauce.com/vinetalk/index.php?action=profile;u=443");
            }
            catch { }
        }

        protected void aboutLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AboutForm box = new AboutForm();
            box.Show();
        }

        protected void vinesauceDotcomLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.vinesauce.com/");
            }
            catch { }
        }

        protected void linkLabelForums_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://vinesauce.com/vinetalk/index.php/");
            }
            catch { }
        }

        protected void linkLabelBooru_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://vinesauce.booru.org/");
            }
            catch { }
        }

        #endregion

        #region Form Control Events

        protected void notificationIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.vinesauce.com/");
            }
            catch { }
        }

        protected void notificationIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
            this.Location = new System.Drawing.Point(15, 15);
        }

        protected void notifyTestButton_Click(object sender, EventArgs e)
        {
            notifyTest("Guest : This is a test of the notification system.");
        }

        protected void exitVinewatchXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected void startWithWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartWithWindowsPrompt strtp = new StartWithWindowsPrompt();
            strtp.Show();
        }

        protected void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (gX)
            {
                SoundPlayer snd = new SoundPlayer(Properties.Resources.easteregg);
                snd.Play();
            }

            gX = true;
        }

        protected void minToTrayButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        protected void versionLabel_Click(object sender, EventArgs e)
        {
            SoundPlayer snd = new SoundPlayer(Properties.Resources.MANGO1);
            snd.Play();
            pictureBox1.Image = Properties.Resources.Mango;
        }

        protected void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.bigger_icon;
            pictureBoxArt.Hide();
        }



        protected void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VineConf conf = new VineConf(this);
            conf.importConfig();

            con.sortAndPruneStreamerList();
        }

        protected void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VineConf conf = new VineConf(this);
            conf.exportConfig();
        }

        protected void panel1_DoubleClick(object sender, EventArgs e)
        {
            Debug.WriteLine("Icon as String - " + getIconsAsString());
        }

        protected void goToVinesaucecomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.vinesauce.com/");
            }
            catch { }
        }

        protected void newLabel_MouseEnter(object sender, EventArgs e)
        {
            newLabel.Hide();
        }

        #endregion

        #region Misc methods

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            switch (MessageBox.Show(this, "Are you  sure you want to close?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }

        #endregion

    }
}
