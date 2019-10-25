using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class Podcast
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public Category Type { get; set; }
        public List<Episode> Episodes { get; set; }

        protected Podcast(string title, string url, Category type)
        {
            Title = title;
            Url = url;
            Type = type;
        }
    }
}
