using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;
using Data;
using System.Text;

namespace Logic
{
    public class PodcastHandler
    {
        public static List<Podcast> GetPodcastFeed()
        {
            List<Podcast> Podcastlista = new List<Podcast>();
            string title = "";
            string url = "";
            string rssFeedurl = "http://borssnack.libsyn.com/rss";
            using (XmlReader reader = XmlReader.Create(rssFeedurl))
            {
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                //Console.WriteLine(feed.Title.Text);
                //Console.WriteLine(feed.Links[0].Uri);
                foreach (SyndicationItem item in feed.Items)
                {
                    Podcast nyPodd = new Podcast();
                    nyPodd.Title  += item.Title.Text;
                    nyPodd.Url += item.Links[0].Uri.OriginalString;
                    Podcastlista.Add(nyPodd);
                }
                return Podcastlista;
            }
        }

    }
}