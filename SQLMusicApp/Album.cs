using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLMusicApp
{
    internal class Album
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string ArtistName { get; set; }
        public int ReleaseYear { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        // Later make a List<Track> songs
        public List<Track> Tracks { get; set; }

    }
}
