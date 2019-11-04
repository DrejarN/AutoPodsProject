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
    public class PodcastHandler : IPod
    {
        public SerializerService serializer = new SerializerService();
        public CategoryDatabase cDB = new CategoryDatabase();
        public PodcastDatabase pDB = new PodcastDatabase();
        public EpisodeDatabase eDB = new EpisodeDatabase();
        public Validation validate = new Validation();
        List<Podcast> deserializedPodcasts;
        public string filenameForJson {get; set;}

        public PodcastHandler()
        {
            this.filenameForJson = @"C:\podFeeds\poddar.txt";
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

        public List<Podcast> getPodList()
        {
            List<Podcast> returnList = new List<Podcast>();
            if (validate.IfFileExists(@"C:\podFeeds\poddar.txt"))
            {
                foreach (Podcast pod in pDB.Podcasts)
                {
                    returnList.Add(pod);
                }
            }
            return returnList;
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
            List<Episode> newEpList = new List<Episode>();
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
                    Episode nyEp = new Episode(epTitle, eDesc, x);
                    newEpList.Add(nyEp);
                    x++;
                }

                return pDB.AddPodcast(title, Url, category, newEpList, x, UpdateFreq);
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
            FrequencyInMin.Add("13");
            FrequencyInMin.Add("30");
            FrequencyInMin.Add("60");
            return FrequencyInMin;
        }
        public List<Episode> UpdateEpisodes(string url)
        {
            pDB.Podcasts = deserializedPodcasts;
            int x = 3;
            List<Episode> allEpisodes = new List<Episode>();
            using (XmlReader reader = XmlReader.Create(url))
            {
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                foreach (SyndicationItem item in feed.Items)
                {
                    Episode episode = new Episode(item.Title.Text, item.Summary.Text, x);
                    allEpisodes.Add(episode);
                    x++;
                }
            }
            foreach(Podcast pod in pDB.Podcasts)
            { 
                if(pod.Url == url)
                {
                    pod.Episodes = allEpisodes;
                }
            }
            serializer.Serialize<Podcast>(@"C:\podFeeds\poddar.txt", pDB.Podcasts);
            return allEpisodes;
        }
    }
}