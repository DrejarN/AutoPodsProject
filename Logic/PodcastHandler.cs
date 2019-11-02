using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;
using Data;
using System.Linq;
using System.Xml.Linq;
using System;
using System.Timers;
using SharedModels;

namespace Logic
{
    public class PodcastHandler
    {
        SerializerService serializer = new SerializerService();
        EntityHandler eHandler = new EntityHandler();
        CategoryDatabase cDB = new CategoryDatabase();
        PodcastDatabase pDB = new PodcastDatabase();
        EpisodeDatabase eDB = new EpisodeDatabase();
        List<Podcast> deserializedPodcasts; 

        //public virtual void deserializePod()
        //{
        //    if (eHandler.IfFileExists(@"C:\podFeeds\poddar.txt")) {
        //        pDB.Podcasts = serializer.Deserialize<Podcast>(@"C:\podFeeds\poddar.txt");
        //        this.deserializedPodcasts = pDB.Podcasts;
        //    }
                
            
        //}

        public List<string> FillCategoryList() //Fyller hela kategorilistan från en JSON fil där de är sparade?
        {
            List<string> CategoryNameList = new List<string>();
            if (eHandler.IfFileExists(@"C:\podFeeds\categories.txt"))
            {
                cDB.categoryDb = serializer.Deserialize<Category>(@"C:\podFeeds\categories.txt");
                foreach (Category category in cDB.categoryDb)
                {
                    CategoryNameList.Add(category.CategoryName);
                }
            }
            return CategoryNameList;
        }


        //public List<Podcast> FillPodcastFeed()
        //{

        //    //List<string> newList = new List<string>();

        //    List<Podcast> podcasts = serializer.Deserialize<Podcast>(@"C:\podFeeds\poddar.txt");
           
        //    return podcasts;
        //}

        //public List<string> FillPodcastFeed() //Fyller podfeeden med content ur nersparad JSON-fil.
        //{
        //        List<Podcast> podcasts = serializer.Deserialize<Podcast>(@"C:\podFeeds\poddar.txt");
        //        List<string> xList = new List<string>();

        //        foreach (Podcast podcast in podcasts)
        //        {
        //            xList.Add(podcast.episodeCount.ToString());
        //            xList.Add(podcast.Title);
        //            xList.Add(podcast.UpdateFrequency);
        //            xList.Add(podcast.categories.CategoryName);
        //        }
        //        return xList;
        //}

        public bool CheckPodcasts()
        {
            bool x = false;
            if(eHandler.IfFileExists(@"C:\podFeeds\poddar.txt"))
            {
                x = true;
            }
            return x;
        }

        
        //public string[] FillEpisodeListOnPodcastClick(string selectedItem) //När man klickar på en podcast i podfeeden displayas alla avsnitt tillhörande Podcasten i avsnittlistan.
        //{
        //    string[] listToArray = new[];

        //        List<Podcast> podcasts = serializer.Deserialize<Podcast>(@"C:\podFeeds\poddar.txt");

        //        //string selItem = PodcastFeed.SelectedItems[0].Text;

        //        foreach (Podcast podcast in podcasts)
        //        {
        //            if (podcast.Title == selectedItem)
        //            {
        //                List<Episode> x = podcast.Episodes;
        //                for (int i = 0; i < x.Count(); i++ )
        //                {   
        //                    listToArray[i] = { x. }
        //                    //episodeList.Items.Add(listToArray[0]);
        //                }
        //            }
        //        }
        //    return listToArray;
        //}
        

        public void FillDescriptionBox() //När du klickar på ett avsnitt i avsnittslistan fylls textboxen till höger med en summary om avsnittet.
        {

        }

        public Podcast GetPodcastFeed(string url, string selectedCategory, string timer)   
        {
            Category selectedCategoryObject = cDB.AddCategory(selectedCategory);
            int x = 3;
            Podcast nyPodd = pDB.AddPodcast();
            string rssFeedurl = url;
            using (XmlReader reader = XmlReader.Create(rssFeedurl))
            {
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                nyPodd.Title += feed.Title.Text;
                nyPodd.Url += feed.Links[0].Uri.OriginalString; //funkar
                nyPodd.categories = selectedCategoryObject;
                nyPodd.UpdateFrequency = timer;
                foreach (SyndicationItem item in feed.Items)
                {
                    string epTitle = item.Title.Text;
                    string eDesc = item.Summary.Text;
                    eDB.AddEpisode(epTitle, eDesc, x);
                    x++;
                }
                nyPodd.episodeCount = x;
                nyPodd.Episodes = eDB.Episodes;
               
                return nyPodd;
            }
        }

        public void addPodcast(string url, string selectedCategory, string timer)
        {
            Podcast newPodcast = GetPodcastFeed(url, selectedCategory, timer);
            if (eHandler.IfFileExists(@"C:\podFeeds\poddar.txt"))
            {
                pDB.Podcasts = serializer.Deserialize<Podcast>(@"C:\podFeeds\poddar.txt");
                pDB.Podcasts.Add(newPodcast);
                serializer.Serialize<Podcast>(@"C:\podFeeds\poddar.txt", pDB.Podcasts);
            }
            else
            {
                pDB.Podcasts.Add(newPodcast);
                serializer.Serialize<Podcast>(@"C:\podFeeds\poddar.txt", pDB.Podcasts);
            }
        }
        public List<Podcast> SortPodcastsByCategory(string category)
        {
                List<Podcast> sortedPodcastList;
                pDB.Podcasts = serializer.Deserialize<Podcast>(@"C:\podFeeds\poddar.txt");
                sortedPodcastList = pDB.Podcasts.OrderByDescending(pod => pod.categories.CategoryName == category).ToList();
                return sortedPodcastList;

          
        }
        public List<string> testMetod()
        {
            List<string> yaho = new List<string>();
            yaho.Add("10");
            yaho.Add("60");
            return yaho;
        }

        //public void TestMethod()
        //{
        //    List<Podcast> podcast = GetPodcastFeed();
        //    serializer.Serialize<Podcast>(@"C:\podFeeds\poddar.txt", podcast);
        //}

        public void UpdateEpisodeViaTimer(string url)
        {
            int x = 1;
            pDB.Podcasts = serializer.Deserialize<Podcast>(@"C:\podFeeds\poddar.txt");
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
        }

        public void StartTimers()
        {
            if (eHandler.IfFileExists(@"C:\podFeeds\poddar.txt"))
            {
                pDB.Podcasts = serializer.Deserialize<Podcast>(@"C:\podFeeds\poddar.txt");
                foreach (Podcast podcast in pDB.Podcasts)
                {
                    var timer = new NamedTimer(podcast.Url);
                    timer.Interval = Int32.Parse(podcast.UpdateFrequency) * 600;
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