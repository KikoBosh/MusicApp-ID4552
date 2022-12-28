using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicApp4552.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public int Age { get; set; }
        public int TopListPosition { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}