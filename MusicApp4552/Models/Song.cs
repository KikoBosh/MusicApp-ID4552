using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicApp4552.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string DownloadLink { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}