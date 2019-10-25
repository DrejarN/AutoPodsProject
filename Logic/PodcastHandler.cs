using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Logic;
using Data;


namespace Logic
{
    public class PodcastHandler
    {

        public void GetPodcastFeed()
        {
            string url = "http://news.google.fr/nwshp?hl=fr&tab=wn&output=rss";
            using (XmlReader reader = XmlReader.Create(url))
            {
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                Console.WriteLine(feed.Title.Text);
                Console.WriteLine(feed.Links[0].Uri);
                foreach (SyndicationItem item in feed.Items)
                {

                }
            }
        }

    }
}
