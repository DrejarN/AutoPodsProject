using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels;

namespace Data
{
    public class EpisodeDatabase : PodcastDatabase
    {
        public List<Episode> Episodes;

        public EpisodeDatabase()
        {
            Episodes = new List<Episode>();
        }

        public Episode AddEpisode(string title, string desc, int nmbr)
        {
            Episode newEpisode = new Episode(title, desc, nmbr);
            Episodes.Add(newEpisode);
            return newEpisode;
        }

        public override List<string> ReturnNamesAsString()
        {
            List<string> NameList = new List<string>();
            foreach (Episode ep in Episodes)
            {
                NameList.Add(ep.Name);
            }
            return NameList;
        }
    }
}
