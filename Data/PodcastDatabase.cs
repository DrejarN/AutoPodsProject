using System.Collections.Generic;

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
            return newPodcast;
        }
        public Podcast AddPodcast(Podcast podcast)
        {
            Podcasts.Add(podcast);
            return podcast;
        }
        public void RemoveFromList(Podcast podcast)
        {
            Podcasts.Remove(podcast);
        }
    }
}
