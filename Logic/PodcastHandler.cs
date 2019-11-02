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
        Validation validator = new Validation();

        //On start-up

        public List<string> FillCategoryList() //Fyller hela kategorilistan från en JSON fil där de är sparade?
        {
            List<string> CategoryNameList = new List<string>();
            if (validator.IfFileExists(@"C:\podFeeds\categories.txt"))
            {
                List<Category> categories = serializer.Deserialize<Category>(@"C:\podFeeds\categories.txt");
                foreach (Category category in categories)
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
            if(validator.IfFileExists(@"C:\podFeeds\poddar.txt"))
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
            Category selectedCategoryObject = new Category(selectedCategory);
            int x = 1;
            List<Episode> episodeList = new List<Episode>();
            Podcast nyPodd = new Podcast();
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
                    Episode oneEpisode = new Episode(epTitle, eDesc, x);
                    episodeList.Add(oneEpisode);
                    x++;
                }
                nyPodd.episodeCount = x;
                nyPodd.Episodes = episodeList;
               
                return nyPodd;
            }
        }

        public void addPodcast(string url, string selectedCategory, string timer)
        {
                Podcast newPodcast = GetPodcastFeed(url, selectedCategory, timer);
                if (validator.IfFileExists(@"C:\podFeeds\poddar.txt"))
                {
                    List<Podcast> oldPodcasts = serializer.Deserialize<Podcast>(@"C:\podFeeds\poddar.txt");
                    oldPodcasts.Add(newPodcast);
                    serializer.Serialize<Podcast>(@"C:\podFeeds\poddar.txt", oldPodcasts);
                }
                else
                {
                    List<Podcast> newPodList = new List<Podcast>();
                    newPodList.Add(newPodcast);
                    serializer.Serialize<Podcast>(@"C:\podFeeds\poddar.txt", newPodList);
                } 
            
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
            List<Episode> episodeList = new List<Episode>();
            int x = 1;
            List<Podcast> podcasts = serializer.Deserialize<Podcast>(@"C:\podFeeds\poddar.txt");
            foreach (Podcast podcast in podcasts)
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
                            Episode oneEpisode = new Episode(epTitle, eDesc, x);
                            episodeList.Add(oneEpisode);
                            x++;
                        }

                    }
                    podcast.Episodes = episodeList;
                }

                
            }
            serializer.Serialize<Podcast>(@"C:\podFeeds\poddar.txt", podcasts);
        }

        public void StartTimers()
        {
            if (validator.IfFileExists(@"C:\podFeeds\poddar.txt"))
            {
                List<Podcast> podcasts = serializer.Deserialize<Podcast>(@"C:\podFeeds\poddar.txt");
                foreach (Podcast podcast in podcasts)
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