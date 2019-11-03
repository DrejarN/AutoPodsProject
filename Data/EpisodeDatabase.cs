﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModels;

namespace Data
{
    public class EpisodeDatabase
    {
        public List<Episode> Episodes;

        public EpisodeDatabase()
        {
            Episodes = new List<Episode>();
        }

        public Episode AddEpisode(string title, string desc, int nmbr)
        {
            Episode newEpisode = new Episode(title, desc, nmbr);
            Episodes.Add(newEpisode);
            return newEpisode;
        }
    }
}
