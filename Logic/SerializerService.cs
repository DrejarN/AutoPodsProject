using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public SerializerService() {
        }
        private JsonSerializer CreateSerializer()
        {
            return new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.All
            };
        }

        //Generisk serializer, deserializer

        public void Serialize<T>(string filename, List<T> Lists)
        {
            try
            {
                var serializer = CreateSerializer();
                using (var sw = new StreamWriter(filename))
                {
                    using (var jw = new JsonTextWriter(sw))
                    {
                        serializer.Formatting = Formatting.Indented;
                        serializer.Serialize(jw, Lists);
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception(filename);
            }
        }

        public List<T> Deserialize<T>(string filename)
        {
            try
            {
                var serializer = CreateSerializer();
                using (var sr = new StreamReader(filename))
                {
                    using (var jr = new JsonTextReader(sr))
                    {
                        var list = serializer.Deserialize<List<T>>(jr);
                        return list;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

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
            
    }
}
