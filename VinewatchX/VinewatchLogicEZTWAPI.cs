using System;
using System.Diagnostics;
using System.Net;
using System.Net.Json;
using System.Windows.Forms;
using VinewatchX.Forms;

namespace VinewatchX
{
    /// <summary>
    /// This is a reimplementation of the twitch api using the EZTWAPI proxy
    /// for preprocessing the JSON requests. This allows for ghost updates if the Twitch Api changes.
    /// </summary>
    public class VinewatchLogicEZTWAPI
    {
        private string eztwapiURL = "http://perso.maskatel.net/lib/EZTWAPI/GETSTATUS.php";

        // ready for multi-channel implementation
        private string service = "twitch";   //twitch, hitbox
        private string channel = "ircluzar";    //channel name
        private bool showChannelName = false;

        private string lastReport = "init";
        private string lastLastReport;

        public bool threaded = false;       //I forgot what this is but it seems important.
        private bool twitchTvState;         //Live status of stream
        private bool twitchTvPrevAlert;     //Alert Suppression

        private int pollRate = 30;
        private MainForm parentForm;        //There is definately a better way of doing this.

        public VinewatchLogicEZTWAPI(MainForm t)
        {
            parentForm = t;
        }

        /// <summary>
        /// Starts the stream checking logic. Should be ran as a thread.
        /// </summary>
        public void init()
        {
            Debug.WriteLine("VinewatchLogic.cs\tThreading Started");

            while (true)
            {
                using (WebClient htmlGet = new WebClient())
                {
                    Debug.WriteLine("VinewatchLogic.cs\thtmlGet");
                    try
                    {
                        String status = htmlGet.DownloadString(eztwapiURL + "?channel=" + channel.ToLower() + "&showname=" + showChannelName.ToString() + "&service=" + service);

                        if (!status.Contains("is Offline"))
                        {
                            Debug.WriteLine("VinewatchLogic.cs\tEZTWAPI get successful");

                            this.twitchTvState = true;

                            setLastLastReport(getLastReport());         // Merge these
                            //setLastReport(getTwitchTitle(twitchJson));  // two methods?
                            setLastReport(status);  // two methods?

                            Debug.WriteLine("VinewatchLogic.cs\t\n*\t\tLast Report:\t" + getLastReport());
                            Debug.WriteLine("VinewatchLogic.cs\t\n*\tLast Last Report:\t" + getLastLastReport());

                            if (this.twitchTvPrevAlert == false || lastLastReport != lastReport)
                            {

                                Debug.WriteLine("VinewatchLogic.cs\tNotification will now occur.");
                                this.twitchTvPrevAlert = true;

                                parentForm.notify(getLastReport());

                                updateFormProperties(getLastReport());
                                updateFormIcon(true);
                            }
                        }
                        else
                        {
                            Debug.WriteLine("VinewatchLogic.cs\tJSON Length check yielded an empty check");
                            this.twitchTvPrevAlert = false;
                            this.twitchTvState = false;
                            updateFormIcon(false);
                            updateFormProperties((showChannelName ? "[" + channel + "] ":"") + DateTime.Now.ToString("HH:mm:ss tt") + ": Nothing Live right now.");
                        }
                    }
                    catch (WebException)
                    {
                        Debug.WriteLine("VinewatchLogic.cs\tWeb Exception");
                        Debug.WriteLine("VinewatchLogic.cs\t\t\n*\tLast Report:\t" + getLastReport());
                        Debug.WriteLine("VinewatchLogic.cs\t\n*\tLast Last Report:\t" + getLastLastReport());

                        if (!parentForm.opt.supressionRadioButton.Checked)
                        {
                            parentForm.notify("TwitchTV: No connection Retrying in 30...");
                        }

                        this.twitchTvPrevAlert = false;
                        this.twitchTvState = false;
                        updateFormIcon(false);
                        updateFormProperties((showChannelName?"["+channel+"] ":"") + DateTime.Now.ToString("HH:mm:ss tt") + ": Nothing Live right now.");
                    }
                    catch (Exception e)
                    {
                        if (!parentForm.opt.supressionRadioButton.Checked)
                        {
                            parentForm.notify("TwitchTV: No connection Retrying in 30...");
                        }
                        this.twitchTvPrevAlert = false;
                        this.twitchTvState = false;
                        updateFormIcon(false);
                        updateFormProperties((showChannelName ?"[" + channel + "] ":"") + DateTime.Now.ToString("HH:mm:ss tt") + ": Nothing Live right now.");
                        MessageBox.Show(e.ToString());
                    }
                }

                if (this.twitchTvState == false)
                {
                    this.twitchTvPrevAlert = false;
                    this.twitchTvState = false;
                    updateFormIcon(false);
                    updateFormProperties((showChannelName?"["+channel+"] ":"") + DateTime.Now.ToString("HH:mm:ss tt") + ": Nothing Live right now.");
                }



                System.Threading.Thread.Sleep(pollRate * 1000);   //30 seconds
            }
        }

        public string getLastReport()
        {
            return this.lastReport;
        }

        public string getLastLastReport()
        {
            return this.lastLastReport;
        }

        public void setLastReport(string s)
        {
            this.lastReport = s;
        }

        public void setLastLastReport(string s)
        {
            this.lastLastReport = s;
        }

        public int getPollRate()
        {
            return this.pollRate;
        }

        public void setPollRate(int n)
        {
            this.pollRate = n;
        }

        private void updateFormProperties(string s)
        {
            parentForm.notifyX(s);
        }

        private void updateFormIcon(bool f)
        {
            if (f)
            {
                parentForm.notificationIcon.Icon = Properties.Resources.live;
            }
            else
            {
                parentForm.notificationIcon.Icon = parentForm.notificationIconIcon;
            }
        }

        /// <summary>
        /// Given a JSON request passed as a string, extracts the TwitchTV channel's current stream title.
        /// </summary>
        /// <param name="s">JSON string</param>
        /// <returns>The title of the stream</returns>
        private String getTwitchTitle(String s)
        {
            String startTag = "status";

            JsonTextParser parser = new JsonTextParser();
            JsonObject obj = parser.Parse(s);

            //Debug.WriteLine(obj.ToString());

            string[] metas = obj.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (String eachLine in metas)
            {
                if (eachLine.Contains(startTag))
                {
                    try
                    {
                        string x = eachLine.Substring(15, eachLine.Length - 17);
                        Debug.WriteLine(x);
                        return x;        /* 2 (+2=14) strips shit of the end.    */
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                }
            }

            return null;
        }
    }
}
