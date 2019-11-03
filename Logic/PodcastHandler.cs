using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;
using Data;
using System.Linq;
using System.Xml.Linq;
using System;
using System.Timers;
using SharedModels;
using System.Threading.Tasks;

namespace Logic
{
    public class PodcastHandler
    {
        public SerializerService serializer = new SerializerService();
        public CategoryDatabase cDB = new CategoryDatabase();
        public PodcastDatabase pDB = new PodcastDatabase();
        public EpisodeDatabase eDB = new EpisodeDatabase();
        public Validation validate = new Validation();
        List<Podcast> deserializedPodcasts;
        string filenameForJson = @"C:\podFeeds\poddar.txt";

        public PodcastHandler()
        {
            deserializeList(filenameForJson);
        }
        public virtual void deserializeList(string filename)
        {
            if (validate.IfFileExists(@"C:\podFeeds\poddar.txt"))
            {
                pDB.Podcasts = serializer.Deserialize<Podcast>(@"C:\podFeeds\poddar.txt");
                this.deserializedPodcasts = pDB.Podcasts;
            }
        }

        public bool CheckPodcasts()
        {
            bool x = false;
            if(validate.IfFileExists(@"C:\podFeeds\poddar.txt"))
            {
                x = true;
            }
            return x;
        }
        public void FillDescriptionBox() //När du klickar på ett avsnitt i avsnittslistan fylls textboxen till höger med en summary om avsnittet.
        {

        }

        public async Task<Podcast> GetPodcastFeed(string url, string selectedCategory, string timer)   
        {
            Category selectedCategoryObject = cDB.AddCategory(selectedCategory);
            int x = 1;
            string rssFeedurl = url;
            using (XmlReader reader = XmlReader.Create(rssFeedurl, new XmlReaderSettings() { Async = true }))
            {
                SyndicationFeed feed = await Task.Run(() => SyndicationFeed.Load(reader));
                string title = feed.Title.Text;
                string Url = feed.Links[0].Uri.OriginalString;
                Category category = selectedCategoryObject;
                string UpdateFreq = timer;
                foreach (SyndicationItem item in feed.Items)
                {
                    string epTitle = item.Title.Text;
                    string eDesc = item.Summary.Text;
                    eDB.AddEpisode(epTitle, eDesc, x);
                    x++;
                }

                return pDB.AddPodcast(title, Url, category, eDB.Episodes, x, UpdateFreq);
            }
        }

        public void RemovePodcastFromList(string podcastName)
        {
            try
            {
                pDB.Podcasts = deserializedPodcasts;
                Podcast podcastRemoved = pDB.Podcasts.FirstOrDefault(a => a.Title == podcastName);
                pDB.RemoveFromList(podcastRemoved);
                serializer.Serialize(@"C:\podFeeds\poddar.txt", pDB.Podcasts);
                deserializeList(filenameForJson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ChangePodcastFromList(string podcastName, string url, string freq, string category)
        {
            try
            {
                pDB.Podcasts = deserializedPodcasts;
                Podcast podcastChanged = pDB.Podcasts.FirstOrDefault(a => a.Title == podcastName);
                podcastChanged.Url = url;
                podcastChanged.UpdateFrequency = freq;
                podcastChanged.categories = cDB.AddCategory(category);
                serializer.Serialize(@"C:\podFeeds\poddar.txt", pDB.Podcasts);
                deserializeList(filenameForJson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task addPodcast(string url, string selectedCategory, string timer)
        {
            Podcast result = await Task.Run(() => GetPodcastFeed(url, selectedCategory, timer));
            if (validate.IfFileExists(@"C:\podFeeds\poddar.txt"))
            {
                pDB.Podcasts = deserializedPodcasts;
                pDB.AddPodcast(result);
                serializer.Serialize<Podcast>(@"C:\podFeeds\poddar.txt", pDB.Podcasts);
                deserializeList(filenameForJson);
            }
            else
            {
                pDB.AddPodcast(result);
                serializer.Serialize<Podcast>(@"C:\podFeeds\poddar.txt", pDB.Podcasts);
                deserializeList(filenameForJson);
            }
        }
        public List<Podcast> SortPodcastsByCategory(string category)
        {
                List<Podcast> sortedPodcastList;
                pDB.Podcasts = deserializedPodcasts;
            sortedPodcastList = pDB.Podcasts.OrderByDescending(pod => pod.categories.CategoryName == category).ToList();
                return sortedPodcastList;

          
        }
        public List<string> AllowedUpdateFrequencyList()
        {
            List<string> FrequencyInMin = new List<string>();
            FrequencyInMin.Add("15");
            FrequencyInMin.Add("30");
            FrequencyInMin.Add("60");
            return FrequencyInMin;
        }
        public void UpdateEpisodeViaTimer(string url)
        {
            int x = 1;
            pDB.Podcasts = deserializedPodcasts;
            List<Episode> newEpList = new List<Episode>();
            foreach (Podcast podcast in pDB.Podcasts)
            {
                if (podcast.Url == url)
                {
                    using (XmlReader reader = XmlReader.Create(url))
                    {
                        SyndicationFeed feed = SyndicationFeed.Load(reader);
                        foreach (SyndicationItem item in feed.Items)
                        {
                            string epTitle = item.Title.Text;
                            string eDesc = item.Summary.Text;
                            Episode nyEp = new Episode(epTitle, eDesc, x);
                            x++;
                            newEpList.Add(nyEp);
                        }

                    }
                    podcast.Episodes = newEpList;
                }

                
            }
            serializer.Serialize<Podcast>(@"C:\podFeeds\poddar.txt", pDB.Podcasts);
            deserializeList(filenameForJson);
        }

        public void StartTimers()
        {
            if (validate.IfFileExists(@"C:\podFeeds\poddar.txt"))
            {
                pDB.Podcasts = deserializedPodcasts;
                foreach (Podcast podcast in pDB.Podcasts)
                {
                    var timer = new NamedTimer(podcast.Url);
                    timer.Interval = Int32.Parse(podcast.UpdateFrequency) * 6000;
                    timer.Elapsed += OnTimedEvent;
                    timer.Start();

                }
            }
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            NamedTimer timer = source as NamedTimer;
            UpdateEpisodeViaTimer(timer.name);
        }

    }
}