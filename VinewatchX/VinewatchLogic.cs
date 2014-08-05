using System;
using System.Diagnostics;
using System.Net;
using System.Net.Json;
using VinewatchX.Forms;

namespace VinewatchX
{
    /// <summary>
    /// Most of the logic for Vinewatch X was lifted from the Python Beta and the now deprecated Vinewatch Sharp.
    /// A lot of cleaning is due in here.
    /// </summary>
    public class VinewatchLogic
    {
        private string twitchTVstreamURL = "https://api.twitch.tv/kraken/streams?channel=vinesauce";
        private string lastReport = "init";
        private string lastLastReport;

        public bool threaded = false;       //I forgot what this is but it seems important.
        private bool twitchTvState;          //Live status of stream
        private bool twitchTvPrevAlert;      //Alert Suppression

        private int pollRate = 30;
        private MainForm parentForm;             //There is definately a better way of doing this.

        public VinewatchLogic(MainForm t)
        {
            parentForm = t;
        }

        public VinewatchLogic(MainForm t, string targetURL)
        {
            setTwitchTVStreamURL(targetURL);
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
                        String twitchJson = htmlGet.DownloadString(twitchTVstreamURL);

                        if (twitchJson.Length > 5)
                        {
                            Debug.WriteLine("VinewatchLogic.cs\tJSON Length check successful");

                            this.twitchTvState = true;

                            setLastLastReport(getLastReport());         // Merge these
                            setLastReport(getTwitchTitle(twitchJson));  // two methods?

                            if (this.twitchTvPrevAlert == false || getLastReport() != getTwitchTitle(twitchJson))
                            {

                                if (getLastReport() != getLastLastReport())
                                {
                                    Debug.WriteLine("VinewatchLogic.cs\tNotification will now occur.");
                                    this.twitchTvPrevAlert = true;

                                    setLastLastReport(getLastReport());         // Merge these
                                    setLastReport(getTwitchTitle(twitchJson));  // two methods?

                                    parentForm.notify(getLastReport());
                                }

                                updateFormProperties(getLastReport());
                                updateFormIcon(true);

                                Debug.WriteLine("VinewatchLogic.cs\t\n*\t\tLast Report:\t" + getLastReport());
                                Debug.WriteLine("VinewatchLogic.cs\t\n*\tLast Last Report:\t" + getLastLastReport());
                            }
                        }
                        else
                        {
                            Debug.WriteLine("VinewatchLogic.cs\tJSON Length check yielded an empty check");
                            this.twitchTvPrevAlert = false;
                            this.twitchTvState = false;
                            updateFormIcon(false);
                            updateFormProperties(DateTime.Now.ToString("HH:mm:ss tt") + ": Nothing Live right now.");
                        }
                    }
                    catch (WebException)
                    {
                        Debug.WriteLine("VinewatchLogic.cs\tWeb Exception");
                        Debug.WriteLine("VinewatchLogic.cs\t\t\n*\tLast Report:\t" + getLastReport());
                        Debug.WriteLine("VinewatchLogic.cs\t\n*\tLast Last Report:\t" + getLastLastReport());

                        if (!parentForm.supressionRadioButton.Checked)
                        {
                            parentForm.notify("TwitchTV: No connection Retrying in 30...");
                        }

                        this.twitchTvPrevAlert = false;
                        this.twitchTvState = false;
                        updateFormIcon(false);
                        updateFormProperties(DateTime.Now.ToString("HH:mm:ss tt") + ": Nothing Live right now.");
                    }
                    catch
                    {
                        if (!parentForm.supressionRadioButton.Checked)
                        {
                            parentForm.notify("TwitchTV: No connection Retrying in 30...");
                        }
                        this.twitchTvPrevAlert = false;
                        this.twitchTvState = false;
                        updateFormIcon(false);
                        updateFormProperties(DateTime.Now.ToString("HH:mm:ss tt") + ": Nothing Live right now.");
                    }
                }

                if (this.twitchTvState == false)
                {
                    this.twitchTvPrevAlert = false;
                    this.twitchTvState = false;
                    updateFormIcon(false);
                    updateFormProperties(DateTime.Now.ToString("HH:mm:ss tt") + ": Nothing Live right now.");
                }



                System.Threading.Thread.Sleep(pollRate * 1000);   //30 seconds
            }
        }

        public string getTwitchTVStreamURL()
        {
            return this.twitchTVstreamURL;
        }

        public void setTwitchTVStreamURL(string s)
        {
            this.twitchTVstreamURL = s;
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
                    //break;                                                    /* 12 skips Title and punctuations      */
                    Debug.WriteLine(eachLine.Substring(12, eachLine.Length - 14));
                    return eachLine.Substring(15, eachLine.Length - 17);        /* 2 (+2=14) strips shit of the end.    */
                }
            }

            //Last resort. This should never occur.
            String endTag = "video_height";
            return @s.Substring(s.IndexOf(startTag) + 8, s.IndexOf(endTag) - s.IndexOf(startTag) - 13);
        }
    }
}
