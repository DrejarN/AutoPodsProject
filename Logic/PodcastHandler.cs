using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;
using Data;
using System.Linq;
using System.Xml.Linq;

namespace Logic
{
    public class PodcastHandler
    {
        public static List<Podcast> GetPodcastFeed()   
        {
            List<Podcast> Podcastlista = new List<Podcast>();
            string rssFeedurl = "http://borssnack.libsyn.com/rss";
            using (XmlReader reader = XmlReader.Create(rssFeedurl))
            {
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                foreach (SyndicationItem item in feed.Items)
                {
                    Podcast nyPodd = new Podcast();
                    nyPodd.Title  += item.Title.Text; //funkar
                    nyPodd.Url += item.Links[0].Uri.OriginalString; //funkar
                    nyPodd.Description = item.Summary.Text; //funkar men tar med <p> taggar
                    //nyPodd.Type = item.Categories.attributes().text);//funkar ej, antagligen för att vår category är en klass
                    //nyPodd.Type = item.ElementExtensions.ReadElementExtensions<XElement>("category", ns)
                    //            .Select(e => e.Value).First();
                    Podcastlista.Add(nyPodd);
                }
                return Podcastlista;
            }
        }

    }
}