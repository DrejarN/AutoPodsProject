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


        public List<string> FillPodcastFeed() //Fyller podfeeden med content ur nersparad JSON-fil.
        {
            List<Category> categories = serializer.Deserialize<Category>(@"C:\podFeeds\categories.txt");
            List<Podcast> podcasts = serializer.Deserialize<Podcast>(@"C:\podFeeds\poddar.txt");
            List<string> xList = new List<string>();

            foreach(Podcast podcast in podcasts)
            {
                xList.Add(podcast.episodeCount.ToString());
                xList.Add(podcast.Title);
                xList.Add("Var 10:e minut");
                xList.Add("Exempel kategori");
            }

            return xList;
        }

        public void FillEpisodeListOnPodcastClick() //När man klickar på en podcast i podfeeden displayas alla avsnitt tillhörande Podcasten i avsnittlistan.
        {

        }

        public void FillDescriptionBox() //När du klickar på ett avsnitt i avsnittslistan fylls textboxen till höger med en summary om avsnittet.
        {

        }

        public static List<Podcast> GetPodcastFeed()   
        {
            int x = 1;
            List<Episode> episodeList = new List<Episode>();
            List<Podcast> Podcastlista = new List<Podcast>();
            string rssFeedurl = "http://borssnack.libsyn.com/rss";
            using (XmlReader reader = XmlReader.Create(rssFeedurl))
            {
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                Podcast nyPodd = new Podcast();
                nyPodd.Title += feed.Title.Text;
                nyPodd.Url += feed.Links[0].Uri.OriginalString; //funkar
                foreach (SyndicationItem item in feed.Items)
                {
                    string episodeTitle = item.Title.Text;
                    string episodeDesc = item.Summary.Text;
                    Episode oneEpisode = new Episode(episodeTitle, episodeDesc, x);
                    episodeList.Add(oneEpisode);
                    x++;
                }
                nyPodd.episodeCount = x;
                nyPodd.Episodes = episodeList;
                
                Podcastlista.Add(nyPodd);
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