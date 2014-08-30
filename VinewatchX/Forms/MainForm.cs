using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Speech.Synthesis;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using System.Net;

namespace VinewatchX.Forms
{
    public partial class MainForm : Form
    {
        internal const string gVer = "2.0";
        internal string DownloadFolder = "http://perso.maskatel.net/lib/VINEWATCHX/UPDATE/";
        internal const string gVersion = "VinewatchX v" + gVer;
        internal string IconDescriptor = "InternalResource";
        internal Icon notificationIconIcon = Properties.Resources.vs;
        internal VinewatchLogicEZTWAPI thread0;    // Checking live statuses is handled by VinewatchLogic objects
        internal OptionsForm opt = new OptionsForm();

        protected static bool gX = false;   // Control boolean for an easter-egg
        protected int balloonTipTimeout = 3;
        protected static StreamerUtils con = new StreamerUtils();
        protected Icon currentIcon = Properties.Resources.vs;
        protected string mainchannel;

        internal System.Windows.Forms.Timer formThreadWatcher = new System.Windows.Forms.Timer();
        internal string SoundToPlay = "";

        public static MainForm mf = null;

        public static bool ForceClose = false;

        #region Mainform constructor and start-up methods

        internal MainForm(bool tStartMinimized)
        {

            InitializeComponent();
            MainForm.mf = this;
            MainFormPrep();

            if (tStartMinimized || opt.startVinewatchMinimizedCheckbox.Checked) WindowState = FormWindowState.Minimized;


        }

        protected void MainForm_Load(object sender, EventArgs e)
        {

            versionLabel.Text = gVersion;

            //Apply Icons
            applyIcons();

            startThreading();
            createTooltips();

            if(!File.Exists("VinesaucePlayer.exe"))
            {
                openPlayerButton.Enabled = false;
                openVinesaucePlayerToolStripMenuItem.Enabled = false;
            }

            SetSoundTimer();

            // self-updater code
            try
            {
                if (File.Exists("VWUPDATE_NEW.exe"))
                {
                    if (File.Exists("VWUPDATE.exe"))
                        File.Delete("VWUPDATE.exe");

                    File.Move("VWUPDATE_NEW.exe", "VWUPDATE.exe");
                }



                if (File.Exists("VWUPDATE.exe"))
                {
                    string updateVer = gVer;
                    try
                    {
                        using (WebClient htmlGet = new WebClient())
                        {
                            updateVer = htmlGet.DownloadString(DownloadFolder + "version.txt");
                        }
                    }
                    catch { }

                    if (gVer != updateVer)
                    {
                        updateButton.Text += updateVer;
                        updateButton.Visible = true;
                    }
                }
            }
            catch { }
        }

        protected void MainFormPrep()
        {
            thread0 = new VinewatchLogicEZTWAPI(this);


            notificationIcon.BalloonTipClicked += new EventHandler(notificationIcon_BalloonTipClicked);

            //Import local config
            try
            {
                VineConf conf = new VineConf(this);
                conf.bypassPromptsImportConfig(Directory.GetCurrentDirectory());
            }
            catch
            {
                // Don't even bother asking for 

                //MessageBox.Show("Error loading the local config. Default config will now be restored.");
                //con.PopulateDefaultStreamers();
                if (opt.resetToDefaultConfigButton_Click(new object(), new EventArgs(), false))
                    MainFormPrep();

            }
        }

        protected void createTooltips()
        {
            ToolTip muteToolTip = new ToolTip(); muteToolTip.SetToolTip(muteRadioButton, "Checked to mute. Unchecked to what are you, a child?");
            ToolTip supressionToolTip = new ToolTip(); supressionToolTip.SetToolTip(opt.supressionRadioButton, "When checked, disables warnings of failed updates. The poller still retries.");
            ToolTip lastReportLabelToolTip = new ToolTip(); lastReportLabelToolTip.SetToolTip(lastReportLabel, "Last report from the stream's feed");
            // CREATE SOME TOOLTIPS FAGGOT
        }

        protected void startThreading()
        {
            Thread t = new Thread(() => thread0.init());
            t.IsBackground = true;
            t.Name = "Main thread.";
            t.Start();
            xDebug.WriteLine("Form1.cs\t\tThreading Started");
        }

        #endregion

        #region Notification methods
        internal void notify(string streamTitle,bool showBalloon)
        {
            playNotifySound(streamTitle);

            if(streamTitle.Contains("[" + VinewatchLogicEZTWAPI.channel + "]"))
                notifyX(streamTitle.Substring(streamTitle.IndexOf(']')+1));   // updating main ticker only for main channel


            string channelname = streamTitle.Substring(0, streamTitle.IndexOf(']') + 1);

            string channelstatus = streamTitle.Substring(streamTitle.IndexOf(']') + 2);
                   channelstatus = (channelstatus.Length > 63 ? channelstatus.Substring(0, 63) : channelstatus); 
            setNotificationIconBalloonText(channelstatus, channelname);

            if(showBalloon)
                showBalloonTip(balloonTipTimeout);
        }

        internal void notifyTest(string streamTitle)
        {
            playNotifySound(streamTitle);

            //Record previous text
            string oldNotificationIconText = notificationIcon.Text;

            setNotificationIconBalloonText(streamTitle.Length > 63 ? streamTitle.Substring(0, 63) : streamTitle, "");

            showBalloonTip(balloonTipTimeout);

            //Re-apply old text
            setNotificationIconBalloonText(oldNotificationIconText, "");
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
                if (opt.ttsRadioButton.Checked)
                {
                    new Thread(new ThreadStart(() => playTTS("Vine sauce is Live. " + streamTitle))).Start();
                }
                else
                {
                    StreamerUtils.FindAndPlayStreamerSound(streamTitle);
                }
            }
        }

        /// <summary>
        /// Speaks Text-to-Speech of the given string
        /// </summary>
        /// <param name="phrase">String to be spoken by the TTS engine</param>
        protected void playTTS(string phrase)
        {
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {

                phrase = String.Join(",", phrase.Split('<', '>', '&', ';', '|', '\\', '/', (char)166, (char)124));

                try
                {


                    xDebug.WriteLine("*\tMainForm.cs Phrase:\t" + phrase);

                    PromptBuilder pb = new PromptBuilder();
                    pb.AppendSsmlMarkup("<prosody volume=\"100\">" + phrase + "</prosody>");

                    synth.SetOutputToDefaultAudioDevice();
                    synth.Speak(pb);
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

        protected void setNotificationIconBalloonText(string text, string channel)
        {
            mainchannel = "[" + VinewatchLogicEZTWAPI.channel + "]";
            if(channel.ToLower() == mainchannel.ToLower())
                notificationIcon.Text = text;

            notificationIcon.BalloonTipText = text;
            notificationIcon.BalloonTipTitle = "Vinewatch X : " + channel;
        }

        protected void showBalloonTip(int timeout)
        {
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

        protected void optionsButton_Click(object sender, EventArgs e)
        {
            if (!opt.Visible)
                opt.ShowDialog();
            else
                opt.Focus();
        }

        internal string getPollRate()
        {
            return thread0.getPollRate().ToString();
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

        internal void setParamFromString(string p)
        {
            if(p.Contains("tts="))
            {
                if (p.Substring(p.IndexOf('=') + 1).ToUpper() == "TRUE")
                    opt.ttsRadioButton.Checked = true;
            }
            else if (p.Contains("runatstart="))
            {
                if (p.Substring(p.IndexOf('=') + 1).ToUpper() == "TRUE")
                    opt.runVinewatchStartupCheckbox.Checked = true;
            }
            else if (p.Contains("startminimized="))
            {
                if (p.Substring(p.IndexOf('=') + 1).ToUpper() == "TRUE")
                    opt.startVinewatchMinimizedCheckbox.Checked = true;
            }
            else if (p.Contains("balloontimeout="))
            {
                try
                {
                    setBalloonTipTimeout(Convert.ToInt32(p.Substring(p.IndexOf('=') + 1)));
                }
                catch { }
            }
            else if (p.Contains("pollrate="))
            {
                try
                {
                    setPollRate(Convert.ToInt32(p.Substring(p.IndexOf('=') + 1)));
                   
                }
                catch { }
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
            AboutForm box = new AboutForm(this);
            box.ShowDialog();
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

                //fallback to vinesauce.com if Vinesauce Player can't be found

                if (File.Exists("VinesaucePlayer.exe"))
                {
                    string title = ((NotifyIcon)sender).BalloonTipTitle;
                    string _channel = title.Substring(title.IndexOf('[') + 1, (title.IndexOf(']') - 1) - title.IndexOf('['));
                    openVinesaucePlayer(_channel);
                }
                    
                else
                    System.Diagnostics.Process.Start("http://www.vinesauce.com/");
                
                
            }
            catch 
            {
                new object();
            }
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

        internal void exitVinewatchXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exitVinewatchXToolStripMenuItem_Click(sender, e, false);
        }
        internal void exitVinewatchXToolStripMenuItem_Click(object sender, EventArgs e, bool updateAtExit)
        {
            if (updateAtExit)
                if (!Rights.UAC.ExecuteElevated("VWUPDATE.exe"))
                    return;

            ForceClose = true;
            Application.Exit();
        }

        internal void startWithWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartWithWindowsPrompt strtp = new StartWithWindowsPrompt(this);
            strtp.ShowDialog();
        }

        protected void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (gX)
                OmniPlayer.Play("Samples/easteregg.mp3");

            gX = true;
        }

        protected void minToTrayButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        protected void versionLabel_Click(object sender, EventArgs e)
        {
            OmniPlayer.Play("Samples/MANGO.mp3");

            pictureBox1.Image = Properties.Resources.mango;
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
        }

        protected void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VineConf conf = new VineConf(this);
            conf.exportConfig();
        }

        protected void panel1_DoubleClick(object sender, EventArgs e)
        {
            xDebug.WriteLine("Icon as String - " + getIconsAsString());
        }

        protected void openVinesaucePlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openVinesaucePlayer(null, false);
        }

        protected void goToVinesaucecomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.vinesauce.com/");
            }
            catch { }
        }


        #endregion

        #region Misc methods

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason != CloseReason.FormOwnerClosing && !ForceClose)
            {
                e.Cancel = true;
                minToTrayButton_Click(new object(), e);
                return;
            }

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            if(!ForceClose)
                switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                    default:
                        break;
                }
        }

        protected void openVinesaucePlayer()
        {
            openVinesaucePlayer("vinesauce");
        }

        protected void openVinesaucePlayer(string channel)
        {
            openVinesaucePlayer(channel, true);
        }

        protected void openVinesaucePlayer(string channel, bool live)
        {
            try
            {
                System.Diagnostics.Process.Start("VinesaucePlayer.exe", ( channel == null ? "" : "-channel:" + channel) + (live ? " -live" : ""));
            }
            catch { }
        }


        #endregion

        private void openPlayerButton_Click(object sender, EventArgs e)
        {
            openVinesaucePlayer(null,false);
        }

        private void vinnyEastereggPanel_MouseClick(object sender, MouseEventArgs e)
        {
            OmniPlayer.Play("Samples/rolling.mp3");
        }

        public void SetSoundTimer()
        {
            // i know this timer thing is stupid but the media player api has some kind of
            // security that disables being called from a different thread that it was imported
            // and it also doesn't want to be imported twice for some reason. i might be wrong tho.

            formThreadWatcher = new System.Windows.Forms.Timer();
            formThreadWatcher.Interval = 2000;
            formThreadWatcher.Tick += new EventHandler(safeThreadPlay);
            formThreadWatcher.Start();

        }

        public void safeThreadPlay(object sender, EventArgs e)
        {
            if (SoundToPlay == "")
                return;

            OmniPlayer.Play(SoundToPlay);
            SoundToPlay = "";
        }

        public delegate void PlayMusic(string filename);

        internal void updateButton_Click(object sender, EventArgs e)
        {
            exitVinewatchXToolStripMenuItem_Click(sender, e, true);
        }

    }

    #region Libs

    public static class OmniPlayer
    {
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, int hwndCallback);

        private static void _open(string file)
        {
            string command = "open \"" + file + "\" type MPEGVideo alias MyMp3";
            mciSendString(command, null, 0, 0);
        }

        private static void _play()
        {
            string command = "play MyMp3";
            mciSendString(command, null, 0, 0);
        }

        private static void _stop()
        {
            string command = "stop MyMp3";
            mciSendString(command, null, 0, 0);

            command = "close MyMp3";
            mciSendString(command, null, 0, 0);
        }

        public static void Play(string Filename)
        {

            try { _stop(); }
            catch
            {
                new object();
            }

            try { _open(Filename); }
            catch 
            {
                new object();
            }

            try { _play(); }
            catch 
            {
                new object();
            }
        }

        public static void Stop()
        {
            try { _stop(); }
            catch 
            {
                new object();
            }

        }
    }

    #endregion

}
