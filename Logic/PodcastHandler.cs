﻿using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;
using Data;
using System.Linq;
using System.Xml.Linq;

namespace Logic
{
    public class PodcastHandler
    {
        SerializerService serializer = new SerializerService();
        EntityHandler eHandler = new EntityHandler();
        //On start-up

        public List<string> FillCategoryList() //Fyller hela kategorilistan från en JSON fil där de är sparade?
        {
            List<string> CategoryNameList = new List<string>();
            if (eHandler.IfFileExists(@"C:\podFeeds\categories.txt"))
            {
                List<Category> categories = serializer.Deserialize<Category>(@"C:\podFeeds\categories.txt");
                foreach (Category category in categories)
                {
                    CategoryNameList.Add(category.CategoryName);
                }
            }
            return CategoryNameList;
        }


        public List<string> FillPodcastFeed() //Fyller podfeeden med content ur nersparad JSON-fil.
        {
                List<Podcast> podcasts = serializer.Deserialize<Podcast>(@"C:\podFeeds\poddar.txt");
                List<string> xList = new List<string>();

                foreach (Podcast podcast in podcasts)
                {
                    xList.Add(podcast.episodeCount.ToString());
                    xList.Add(podcast.Title);
                    xList.Add(podcast.UpdateFrequency);
                    xList.Add(podcast.categories.CategoryName);
                }
                return xList;
        }

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
        //                    listToArray[i] = { i.Name; }
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
            if (eHandler.IfFileExists(@"C:\podFeeds\poddar.txt"))
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
            List<string> updateIntervals = new List<string>();
            updateIntervals.Add("15");
            updateIntervals.Add("30");
            updateIntervals.Add("60");
            return updateIntervals;
        }

        //public void TestMethod()
        //{
        //    List<Podcast> podcast = GetPodcastFeed();
        //    serializer.Serialize<Podcast>(@"C:\podFeeds\poddar.txt", podcast);
        //}
    }
}