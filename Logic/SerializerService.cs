using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Newtonsoft.Json;

namespace Logic
{
    public class SerializerService
    {


        public static void SerializerPodcastfeed() //JSON-fil för Podcasts
        {

            List<Podcast> podcasts = PodcastHandler.GetPodcastFeed();

            try
            {
                using (StreamWriter file = File.CreateText(@"C:\podFeeds\pdfeed.txt"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    using (var jw = new JsonTextWriter(file))
                    {
                        serializer.Formatting = Formatting.Indented;
                        serializer.Serialize(jw, podcasts);
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public static void SerializerCategories(List<Category> categories) //JSON-fil för kategorier
        {
            try
            {
                using (StreamWriter file = File.CreateText(@"C:\podFeeds\categories.txt"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    using (var jw = new JsonTextWriter(file))
                    {
                        serializer.Formatting = Formatting.Indented;
                        serializer.Serialize(jw, categories);
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }





        public List<Podcast> DeserializeJSON() //Metoden ej testad.
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                //var serializer = CreateSerializer();
                using (var sr = new StreamReader(@"C:\podFeeds\path.txt"))
                {
                    using (var jr = new JsonTextReader(sr))
                    {
                        var list = serializer.Deserialize<List<Podcast>>(jr);
                        return list;
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        
    }
}
