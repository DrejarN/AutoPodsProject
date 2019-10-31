using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Episode : Podcast
    { 
        public string Name { get; set; }

        public string Description { get; set; }
        public Episode(string title, string url, Category type, int episodeLength, string name) : base (title, url, type)
        {
           // EpisodeLength = episodeLength;
            Name = name;
        }

        public Episode(string title)
        {
            this.Name = title;
        }
    }
}
