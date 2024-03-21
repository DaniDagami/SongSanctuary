using SongSanctuary.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model {
    public class Album {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseYear { get; set; }
        public int SongCount => Songs.Count;
        public int? BandId { get; set; }

        public ICollection<Song> Songs { get; private set; }
        public Band? Band { get; set; }
    }
}
