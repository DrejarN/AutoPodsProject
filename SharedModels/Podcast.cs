using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class Podcast
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public Category categories { get; set; }
        public List<Episode> Episodes { get; set; }
        public int episodeCount { get; set; }
        public string UpdateFrequency { get; set; }
        public Podcast(string title, string url, Category type)
        {
            Title = title;
            Url = url;
            this.categories = type;
        }
        public Podcast()
        {
        }
    }
}
