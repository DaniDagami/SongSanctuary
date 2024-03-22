﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model {
    public class Album {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public int SongCount { get; set; }
        public int? BandId { get; set; }

        public Band? Band { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
