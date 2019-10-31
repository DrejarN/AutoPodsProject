using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Episode
    { 
        public string Name { get; set; }

        public string Description { get; set; }

        public int EpisodeNmbr { get; set; }

        public Episode(string title, string description, int nmbr)
        {
            this.Name = title;
            this.Description = description;
            this.EpisodeNmbr = nmbr;
        }
    }
}
