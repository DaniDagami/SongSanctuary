using System;
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
        public List<Song> Songs { get; set; }

        public Album() {
            Songs = new List<Song>();
        }

        public override string ToString() {
            return $"Id: {Id}, Name: {Name}, Release Year: {ReleaseYear}, Song Count: {SongCount}, Band Id: {(BandId.HasValue ? BandId : "N/A")}";
        }
    }
}
