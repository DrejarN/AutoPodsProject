using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Podcast
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public Category categories { get; set; }
        public List<Episode> Episodes { get; set; }
        public int episodeCount { get; set; }
        public int UpdateFrequency { get; set; }

        public string kategori { get; set; }
        public Podcast(string title, string url, string kategori)
        {
            Title = title;
            Url = url;
            this.kategori = kategori;
        }
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
