using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Json;
using VinewatchX.Forms;

namespace VinewatchX
{
    public class PollerThreadManager
    {
        // Ircluzar: A single thread approach was implemented for multiple streamers in VinewatchLogicEZTWAPI.cs

        // THIS SHIT ISN'T IMPLEMENTED YET

        // Someone on the forums asked me in a PM if I could make the program able to
        // check the live status of numerous TwitchTV streams, and this was my approach.
        // Just a list of objects each of which represent a stream, you get the idea.

        // PollerThreadManager is to PollerThreads as StreamerUtils is to Streamers.

        private MainForm parentForm;
        private List<PollerThread> pollerList = new List<PollerThread>();

        PollerThreadManager(MainForm targetParent)
        {
            parentForm = targetParent;
        }

        public void notify(string s)
        {
            parentForm.notify(s);
        }

        public void sortAndPruneStreamerList()
        {
            pollerList = pollerList.OrderBy(o => o.getPollerDescription()).ToList();

            for (int i = 1; i < pollerList.Count; i++)
            {
                if (pollerList[i].getPollerDescription() == pollerList[i - 1].getPollerDescription())
                {
                    pollerList.RemoveAt(i);
                }
            } // Holy fucking shit I'm l337
        }

        public string getTwitchTitle(string s)
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

        public void addNewPoller(string referenceName, string twitchTVUrl)
        {
            pollerList.Add(new PollerThread(this, referenceName, twitchTVUrl));
        }

        public void removePoller(string tname)
        {
            PollerThread T = null;
            foreach (PollerThread eachPoller in pollerList.Where(x => x.getPollerDescription() == tname))
                T = this.getPollerThreadByDescription(eachPoller.getPollerDescription());
            pollerList.Remove(T);
        }

        public PollerThread getPollerThreadByDescription(string tname)
        {
            foreach (PollerThread eachPoller in pollerList.Where(x => x.getPollerDescription() == tname))
                return eachPoller;
            return null;
        }

        public void changePollerDescriptionByDescription(string TargetPollerDesc, string newPollerDesc)
        {
            foreach (PollerThread eachPoller in pollerList.Where(x => x.getPollerDescription() == TargetPollerDesc))
                eachPoller.setPollerDescription(newPollerDesc);
        }

        public void changePollerDescriptionByURL(string TargetPollerURL, string newPollerDesc)
        {
            foreach (PollerThread eachPoller in pollerList.Where(x => x.getTwitchTVURL() == TargetPollerURL))
                eachPoller.setPollerDescription(newPollerDesc);
        }
    }

    /* ============================================================================================================== */

    public class PollerThread
    {
        private PollerThreadManager parentManager;

        private string pollerDescription;

        private string twitchTVstreamURL = "http://api.justin.tv/api/stream/list.json?channel=vinesauce";
        private string lastReport;

        private bool twitchTvState;
        private bool twitchTvPrevAlert;

        private int pollRate = 30;

        public PollerThread(PollerThreadManager targetParent, string tPollerDescription, string targetURL)
        {
            pollerDescription = tPollerDescription;
            parentManager = targetParent;
            twitchTVstreamURL = targetURL;
        }

        public PollerThread(string tPollerDescription, string targetURL)
        {
            pollerDescription = tPollerDescription;
            twitchTVstreamURL = targetURL;
        }

        private void run()
        {
            Debug.WriteLine("VinewatchLogic.cs\tThreading Started");

            while (true)
            {
                using (WebClient htmlGet = new WebClient())
                {
                    Debug.WriteLine("VinewatchLogic.cs\thtmlGet");
                    try
                    {
                        String twitchJson = htmlGet.DownloadString(getTwitchTVURL());

                        if (twitchJson.Length > 5)
                        {
                            Debug.WriteLine("VinewatchLogic.cs\tJSON Length check successful");

                            this.twitchTvState = true;

                            if (this.twitchTvPrevAlert == false || getLastReport() != parentManager.getTwitchTitle(twitchJson))
                            {
                                Debug.WriteLine("VinewatchLogic.cs\tNotification will now occur.");
                                this.twitchTvPrevAlert = true;
                                setLastReport(parentManager.getTwitchTitle(twitchJson));

                                parentManager.notify(getLastReport());

                                //updateFormProperties(getLastReport());
                                //updateFormIcon(true);
                            }
                        }
                        else
                        {
                            Debug.WriteLine("VinewatchLogic.cs\tJSON Length check yielded an empty check");
                            this.twitchTvPrevAlert = false;
                            this.twitchTvState = false;

                            //updateFormIcon(false);
                            //updateFormProperties(DateTime.Now.ToString("HH:mm:ss tt") + ": Nothing Live right now.");
                        }
                    }
                    catch (WebException)
                    {
                        parentManager.notify("Service: No connection Retrying in 30...");
                        this.twitchTvPrevAlert = false;
                        this.twitchTvState = false;

                        //updateFormIcon(false);
                        //updateFormProperties(DateTime.Now.ToString("HH:mm:ss tt") + ": Nothing Live right now.");
                    }
                    catch
                    {
                        parentManager.notify("Service: No connection Retrying in 30...");
                        this.twitchTvPrevAlert = false;
                        this.twitchTvState = false;

                        //updateFormIcon(false);
                        //updateFormProperties(DateTime.Now.ToString("HH:mm:ss tt") + ": Nothing Live right now.");
                    }
                }

                if (this.twitchTvState == false)
                {
                    this.twitchTvPrevAlert = false;
                    this.twitchTvState = false;

                    //updateFormIcon(false);
                    //updateFormProperties(DateTime.Now.ToString("HH:mm:ss tt") + ": Nothing Live right now.");
                }



                System.Threading.Thread.Sleep(pollRate * 1000);   //30 seconds
            }
        }

        public string getTwitchTVURL()
        {
            return this.twitchTVstreamURL;
        }

        private void setTwitchTVURL(string s)
        {
            this.twitchTVstreamURL = s;
        }

        public string getLastReport()
        {
            return this.lastReport;
        }

        private void setLastReport(string s)
        {
            this.lastReport = s;
        }

        public int getPollRate()
        {
            return this.pollRate;
        }

        public void setPollRate(int n)
        {
            this.pollRate = n;
        }

        public string getPollerDescription()
        {
            return this.pollerDescription;
        }

        public void setPollerDescription(string s)
        {
            this.pollerDescription = s;
        }
    }
}
