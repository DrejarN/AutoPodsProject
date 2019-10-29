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

        private static JsonSerializer CreateSerializer()
        {
            return new JsonSerializer
            {
                TypeNameHandling = TypeNameHandling.All
            };
        }

        //Generisk serializer, deserializer

        public static void Serialize(string filename, List<Object> list)
        {
            try
            {
                var serializer = CreateSerializer();
                using (var sw = new StreamWriter(filename))
                {
                    using (var jw = new JsonTextWriter(sw))
                    {
                        serializer.Formatting = Formatting.Indented;
                        serializer.Serialize(jw, list);
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception(filename);
            }
        }

        public static List<Object> Deserialize(string filename)
        {
            try
            {
                var serializer = CreateSerializer();
                using (var sr = new StreamReader(filename))
                {
                    using (var jr = new JsonTextReader(sr))
                    {
                        var list = serializer.Deserialize<List<Object>>(jr);
                        return list;
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception(filename);
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
