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


        public void FillPodcastFeed() //Fyller podfeeden med content ur nersparad JSON-fil.
        {


        }

        public void FillEpisodeListOnPodcastClick() //När man klickar på en podcast i podfeeden displayas alla avsnitt tillhörande Podcasten i avsnittlistan.
        {

        }

        public void FillDescriptionBox() //När du klickar på ett avsnitt i avsnittslistan fylls textboxen till höger med en summary om avsnittet.
        {

        }

        public static List<Podcast> GetPodcastFeed()   
        {
            List<Episode> episodeList = new List<Episode>();
            List<Podcast> Podcastlista = new List<Podcast>();
            string rssFeedurl = "http://borssnack.libsyn.com/rss";
            using (XmlReader reader = XmlReader.Create(rssFeedurl))
            {
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                foreach (SyndicationItem item in feed.Items)
                {
                    Podcast nyPodd = new Podcast();

                    foreach (Podcast episode in Podcastlista)
                    {
                        string episodeTitle = item.Title.Text;
                        Episode oneEpisode = new Episode(episodeTitle);
                        episodeList.Add(oneEpisode);
                    }
                    nyPodd.Title += item.Links;
                    nyPodd.Url += item.Links[0].Uri.OriginalString; //funkar
                    nyPodd.Episodes = episodeList;
                    Podcastlista.Add(nyPodd);
                }
                return Podcastlista;
            }
        }

        public void TestMethod()
        {
            List<Podcast> podcast = GetPodcastFeed();
            serializer.Serialize<Podcast>(@"C:\podFeeds\poddar.txt", podcast);
        }

    }
}