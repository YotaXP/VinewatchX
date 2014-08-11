using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VinewatchX
{
    /// <summary>
    /// One object is required to handle all streamers used in the program. 
    /// Most likely, actions performed on the list of streamers will be done by said object, including intial configuration of the streamer list should no config be present.
    /// </summary>
    public class StreamerUtils
    {
        public static SortedSet<Streamer> StreamerList { get; private set; }

        public StreamerUtils()
        {
            StreamerList = new SortedSet<Streamer>();
            //this.PopulateDefaultStreamers();        // Populate the streamerList with preset streamers. Used in debugging.
        }

        public void PopulateDefaultStreamers()
        {
            StreamerList.Add(new Streamer("Vinny"));
            //Sorted Alphabetically, not by preference
            StreamerList.Add(new Streamer("Rev"));
            StreamerList.Add(new Streamer("Bobito"));
            StreamerList.Add(new Streamer("Darren"));
            StreamerList.Add(new Streamer("Direboar"));
            StreamerList.Add(new Streamer("Fred"));
            StreamerList.Add(new Streamer("Gingers"));
            StreamerList.Add(new Streamer("Guest"));
            StreamerList.Add(new Streamer("Imakuni"));
            StreamerList.Add(new Streamer("KY"));
            StreamerList.Add(new Streamer("Limes"));
            StreamerList.Add(new Streamer("Study"));
            StreamerList.Add(new Streamer("Joel"));
            StreamerList.Add(new Streamer("Hootey"));       //1.4; 1.7, Sorry Hootey
            StreamerList.Add(new Streamer("Jen"));          //1.4
        }

        public static void AddStreamer(string name)
        {
            var s = new Streamer(name);
            StreamerList.Add(s);
            s.ShowSoundFileSelectDialog();
        }
        internal static void AddStreamer(string newStreamerName, string newSoundFile)
        {
            StreamerList.Add(new Streamer(newStreamerName, newSoundFile));
        }

        public static void RemoveStreamer(string name)
        {
            Streamer s = FindStreamerByName(name);
            if (s != null) StreamerList.Remove(s);
        }

        public static Streamer FindStreamerByName(string name)
        {
            return StreamerList.FirstOrDefault(s => s.Name == name);
        }

        public static Streamer FindStreamerByStreamTitle(string streamTitle)
        {
            return StreamerList.FirstOrDefault(s => streamTitle.ToLowerInvariant().Contains(s.Name.ToLowerInvariant()));
        }

        public static void FindAndPlayStreamerSound(string streamTitle)
        {
            Streamer s = FindStreamerByStreamTitle(streamTitle);
            if (s != null) s.PlaySound();
        }

    }
}
