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
        public Kategori Type { get; set; }
        public List<Episode> Episodes { get; set; }
    }
}
