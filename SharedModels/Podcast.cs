using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

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
        public Timer updateTimer { get; set; }
        public Podcast(string title, string url, Category type, List<Episode> lista, int count, string freq)
        {
            Title = title;
            Url = url;
            this.categories = type;
            this.Episodes = lista;
            episodeCount = count;
            UpdateFrequency = freq;
        }
        public Podcast()
        {
        }
    }
}
