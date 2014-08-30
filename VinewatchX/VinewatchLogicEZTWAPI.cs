using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
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

        // Main channel info
        private string service = "Twitch";                      //main channel service (twitch, hitbox)
        public static volatile string channel = "Vinesauce";    //main channel name

        private int pollRate = 30;
        private MainForm parentForm;        //There is definately a better way of doing this. (no there isn't, MainForm.mf is worse.)
        StreamerChannel currentStreamerChannel = new StreamerChannel("","");

        public VinewatchLogicEZTWAPI(MainForm t)
        {
            parentForm = t;
        }

        /// <summary>
        /// Starts the stream checking logic. Should be ran as a thread.
        /// </summary>
        public void init()
        {
            xDebug.WriteLine("Logic Thread Started");

            while (true)
            {
                using (WebClient htmlGet = new WebClient())
                {
                    xDebug.WriteLine("> htmlGet(s)");
                    try
                    {
                        String status = htmlGet.DownloadString(eztwapiURL + "?channel=" + channel.ToLower() + "&showname=true" + "&service=" + service);

                        List<String[]> allStatus = new List<string[]>();

                        foreach (Streamer str in StreamerUtils.StreamerList)
                        {
                            if(str.MonitorAltChannel)
                            {
                                string status2 = htmlGet.DownloadString(eztwapiURL + "?channel=" + str.AltChannel + "&showname=true" + "&service=" + str.AltService);
                                allStatus.Add(new string[]{str.AltChannel, str.AltService, status2});
                            }
                        }

                        allStatus.Add(new string[] { channel, service, status });   //Main Channel is always the last one
                                                                                    //Because the last crated bubble tooltip is the one on the front

                        foreach(string[] channelstatus in allStatus)
                        {
                            if(channelstatus[0] != "" && channelstatus[1] != "")
                                processStatus(channelstatus[0], channelstatus[1], channelstatus[2]);
                        }
                        
                    }
                    catch (WebException e)
                    {
                        xDebug.WriteLine("!!! >>> Web Exception");

                        if (!parentForm.opt.supressionRadioButton.Checked)
                        {
                            parentForm.notify("Service: No connection Retrying in 30...", true);
                        }

                        currentStreamerChannel.servicePrevAlert = false;
                        currentStreamerChannel.serviceState = false;
                        updateFormIcon(false);
                        updateFormProperties(DateTime.Now.ToString("HH:mm:ss tt") + ": " + VinewatchLogicEZTWAPI.channel + " is currently Offline.");
                        xDebug.WriteLine(DateTime.Now.ToString("HH:mm:ss tt") + ": " + VinewatchLogicEZTWAPI.channel + " is currently Offline.");
                        xDebug.WriteLine(e.ToString());
                    }
                    catch (Exception e)
                    {
                        xDebug.WriteLine("!!! >>> General Exception");
                        if (!parentForm.opt.supressionRadioButton.Checked)
                        {
                            parentForm.notify("Service: No connection Retrying in 30...", true);
                        }
                        currentStreamerChannel.servicePrevAlert = false;
                        currentStreamerChannel.serviceState = false;
                        updateFormIcon(false);
                        updateFormProperties(DateTime.Now.ToString("HH:mm:ss tt") + ": " + VinewatchLogicEZTWAPI.channel + " is currently Offline.");
                        xDebug.WriteLine(DateTime.Now.ToString("HH:mm:ss tt") + ": " + VinewatchLogicEZTWAPI.channel + " is currently Offline.");
                        xDebug.WriteLine(e.ToString());
                    }
                }

                if (currentStreamerChannel.serviceState == false)
                {
                    currentStreamerChannel.servicePrevAlert = false;
                    currentStreamerChannel.serviceState = false;
                    updateFormIcon(false);
                    updateFormProperties(DateTime.Now.ToString("HH:mm:ss tt") + ": " + VinewatchLogicEZTWAPI.channel + " is currently Offline.");
                    xDebug.WriteLine(DateTime.Now.ToString("HH:mm:ss tt") + ": " + VinewatchLogicEZTWAPI.channel + " is currently Offline.");
                }



                System.Threading.Thread.Sleep(pollRate * 1000);   //30 seconds
            }
        }

        public void processStatus(string _channel, string _service, string status)
        {
            if (!status.Contains("is Offline"))
            {

                xDebug.WriteLine(_channel + " on " + _service + " reported online");
                xDebug.WriteLine("with status: " + status);

                StreamerChannel sc = StreamerChannel.getOrAddChannel(_channel, _service);
                currentStreamerChannel = sc; // global var do not change
                sc.serviceState = true;

                sc.setLastLastReport(sc.getLastReport());
                sc.setLastReport(status);

                xDebug.WriteLine(_channel + " on " + _service + "Last Report:\t" + sc.getLastReport());
                xDebug.WriteLine(_channel + " on " + _service + "Last Last Report:\t" + sc.getLastLastReport());

                if (currentStreamerChannel.servicePrevAlert == false || sc.getLastLastReport() != sc.getLastReport())
                {
                    // will display balloon if the ticker string has changed or 
                    //if the service has been online back up after 5 or more offline ticks. (default: 2.5 min)
                    bool showBalloon = (sc.getLastLastReport() != sc.getLastReport() || sc.offlineTicks >= 5);

                    xDebug.WriteLine("> ###### Notification will now occur" + (showBalloon? " with a notification balloon. ######" : " silently. ######"));
                    currentStreamerChannel.servicePrevAlert = true;

                    if(status.Contains("[" + channel + "]"))
                        updateFormIcon(true);


                        parentForm.notify(sc.getLastReport(), showBalloon);

                }

                sc.offlineTicks = 0; //reset the offline ticks counter if seen online
            }
            else
            {
                xDebug.WriteLine("EZTWAPI: " + _channel + " on " + _service + " IS OFFLINE");

                StreamerChannel sc = StreamerChannel.getOrAddChannel(_channel, _service);
                currentStreamerChannel = sc; //global var do not change

                sc.servicePrevAlert = false;
                sc.serviceState = false;
                sc.offlineTicks++;

                if(status.Contains("[" + channel + "]"))
                {
                    updateFormIcon(false);
                    updateFormProperties(DateTime.Now.ToString("HH:mm:ss tt") + ": " + channel + " on " + _service + " is currently Offline.");
                    xDebug.WriteLine(DateTime.Now.ToString("HH:mm:ss tt") + ": " + channel + " on " + _service + " is currently Offline.");
                }

            }
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

        private bool isFormIconLive()
        {
            return (parentForm.notificationIcon.Icon == Properties.Resources.live);
        }
    }

    public class StreamerChannel{
        string channel = "Vinesauce";
        string service = "Twitch";
        public string fullchannel
        {
            get{return channel + "@" + service;}
        }

        public bool serviceState;              //Live status of stream
        public bool servicePrevAlert;          //Alert Suppression

        public int offlineTicks = 0;

        private string lastReport = "init";
        private string lastLastReport;


        public static List<StreamerChannel> MonitoredChannels = new List<StreamerChannel>();

        public static StreamerChannel getOrAddChannel(string _channel, string _service)
        {
            StreamerChannel rtn = null;

            foreach(StreamerChannel item in MonitoredChannels)
                if(item.fullchannel == _channel + "@" + _service)
                {
                    rtn = item;
                        break;
                }

            if(rtn == null){
                rtn = new StreamerChannel(_channel,_service);
                MonitoredChannels.Add(rtn);
            }

            return rtn;
        }

        public StreamerChannel(string _channel, string _service)
        {
            channel = _channel;
            service = _service;
        }

                public string getLastReport()
        {
            return this.lastReport;
        }

        public void setLastReport(string s)
        {
            this.lastReport = s;
        }

        public string getLastLastReport()
        {
            return this.lastLastReport;
        }

        public void setLastLastReport(string s)
        {
            this.lastLastReport = s;
        }

    }
}
