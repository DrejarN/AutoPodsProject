using System;
using System.ServiceModel.Syndication;
using System.Xml;

namespace PresentationLayer
{
    public class TestClassKobben
    {
        public TestClassKobben()
        {
        }

        public void kobbensMetod()
        {
            string url = "http://news.google.fr/nwshp?hl=fr&tab=wn&output=rss";
            using (XmlReader reader = XmlReader.Create(url))
            {
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                Console.WriteLine(feed.Title.Text);
                Console.WriteLine(feed.Links[0].Uri);
                foreach (SyndicationItem item in feed.Items)
                {
                    Console.WriteLine(item.Title.Text);
                }
            }
        }
    }
}
