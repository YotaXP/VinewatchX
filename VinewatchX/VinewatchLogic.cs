using System;
using System.Diagnostics;
using System.Net;
using System.Net.Json;
using VinewatchX.Forms;


namespace VinewatchX
{
    public class VinewatchLogic
    {
        private string twitchTVstreamURL = "http://api.justin.tv/api/stream/list.json?channel=vinesauce";
        private string lastReport = "init";
        private string lastLastReport;  // lmao

        public bool threaded = false;

        private bool twitchTvState;         //Live status of stream
        private bool twitchTvPrevAlert;     //Alert Suppression

        private int pollRate = 30;
        private MainForm parentForm;





        public VinewatchLogic()
        {

        }

        public VinewatchLogic(MainForm t)
        {
            parentForm = t;
        }

        public VinewatchLogic(MainForm t, string targetURL)
        {
            setTwitchTVStreamURL(targetURL);
            parentForm = t;
        }





        public void init(MainForm formAddress)
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

                                Debug.WriteLine("* Last Report:\t" + getLastReport());
                                Debug.WriteLine("* Last Last Report:\t" + getLastLastReport());
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
                        Debug.WriteLine("Web Exception");
                        Debug.WriteLine("* Last Report:\t" + getLastReport());
                        Debug.WriteLine("* Last Last Report:\t" + getLastLastReport());

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

            //Debug.WriteLine("VinewatchLogic.cs\tThread dead!");
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

        private String getTwitchTitle(String s)
        {
            String startTag = "title";

            JsonTextParser parser = new JsonTextParser();
            JsonObject obj = parser.Parse(s);

            //Debug.WriteLine(obj.ToString());

            string[] metas = obj.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (String eachLine in metas)
            {
                if (eachLine.Contains(startTag))
                {
                    //Debug.WriteLine(eachLine);
                    //break;                                                    /* 12 skips Title and punctuations      */
                    Debug.WriteLine(eachLine.Substring(12, eachLine.Length - 14));
                    return eachLine.Substring(12, eachLine.Length - 14);        /* 2 (+2=14) strips shit of the end.    */
                }
            }

            //Last resort. This should never occur.
            String endTag = "video_height";
            return @s.Substring(s.IndexOf(startTag) + 8, s.IndexOf(endTag) - s.IndexOf(startTag) - 13);
        }
    }
}
