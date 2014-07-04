using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace VinewatchX
{
    /// <summary>
    /// One object is required to handle all streamers used in the program. 
    /// Most likely, actions performed on the list of streamers will be done by said object, including intial configuration of the streamer list should no config be present.
    /// </summary>
    public class StreamerUtils
    {
        static private List<Streamer> streamerList = new List<Streamer>();  //ArrayList can suck my big black dick.





        public StreamerUtils()
        {
            //this.populate();        // Populate the streamerList with preset streamers. Used in debugging.
        }





        public void populate()
        {
            streamerList.Add(new Streamer("Vinny"));
            //Sorted Alphabetically, not by preference
            streamerList.Add(new Streamer("Rev"));
            streamerList.Add(new Streamer("Bobito"));
            streamerList.Add(new Streamer("Darren"));
            streamerList.Add(new Streamer("Direboar"));
            streamerList.Add(new Streamer("Fred"));
            streamerList.Add(new Streamer("Gingers"));
            streamerList.Add(new Streamer("Guest"));
            streamerList.Add(new Streamer("Imakuni"));
            streamerList.Add(new Streamer("KY"));
            streamerList.Add(new Streamer("Limes"));  
            streamerList.Add(new Streamer("Study"));
            streamerList.Add(new Streamer("Joel"));
            streamerList.Add(new Streamer("Hootey"));    //1.7+, Sorry Hootey   :s
            streamerList.Add(new Streamer("Jen"));      //1.4
        }

        public void sortAndPruneStreamerList()
        {
            streamerList = streamerList.OrderBy(o => o.getName()).ToList();

            for (int i = 1; i < streamerList.Count; i++)
            {
                if (streamerList[i].getName() == streamerList[i-1].getName())
                {
                    streamerList.RemoveAt(i);
                }
            } // Holy fucking shit I'm l337
        }



        
        
        public void addStreamer(string tname)
        {
            streamerList.Add(new Streamer(tname));
            foreach (Streamer eachStreamer in streamerList.Where(x => x.getName() == tname))
                eachStreamer.setSoundfile();    //Some men just want to watch the world burn.
        }

        public void removeStreamer(string tname)
        {
            Streamer T = null;
            foreach (Streamer eachStreamer in streamerList.Where(x => x.getName() == tname))
                T = this.getStreamerByName(eachStreamer.getName());
            streamerList.Remove(T);
        }

        public Streamer getStreamerByName(string tname)
        {
            foreach (Streamer eachStreamer in streamerList.Where(x => x.getName() == tname))
                return eachStreamer;
            return null;
        }

        public void editStreamerName(Streamer target, string newStreamerName)
        {
            foreach (Streamer eachStreamer in streamerList.Where(x => x == target))
                eachStreamer.setName(newStreamerName);
        }

        public void editStreamerSoundfile(string tname)
        {
            foreach (Streamer eachStreamer in streamerList.Where(x => x.getName() == tname))
                eachStreamer.setSoundfile();
        }

        public void findAndPlayStreamerSound(string streamTitle)
        {
            foreach (Streamer eachStreamer in streamerList.Where(x => streamTitle.Contains(x.getName())))
                eachStreamer.playSound();       //Jesus christ what have I become.
        }

        public List<Streamer> getStreamerList()
        {
            return streamerList;
        }


        internal void addStreamer(string newStreamerName, Stream newSoundFile)
        {
            streamerList.Add(new Streamer(newStreamerName, newSoundFile));
        }

        internal void addStreamer(string newStreamerName, string newSoundFile)
        {
            streamerList.Add(new Streamer(newStreamerName, newSoundFile));
        }
    }
}
