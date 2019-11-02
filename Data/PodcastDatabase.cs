using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels;

namespace Data
{
    public class PodcastDatabase
    {
        public List<Podcast> Podcasts { get; set; }

        public PodcastDatabase()
        {
            Podcasts = new List<Podcast>();
        }
        public Podcast AddPodcast(string title, string url, Category category, List<Episode> lista, int epCount, string freq)
        {
            Podcast newPodcast = new Podcast(title, url, category, lista, epCount, freq);
            Podcasts.Add(newPodcast);
            return newPodcast;
        }
        public Podcast AddPodcast()
        {
            Podcast newPodcast = new Podcast();
            Podcasts.Add(newPodcast);
            return newPodcast;
        }
    }


}
