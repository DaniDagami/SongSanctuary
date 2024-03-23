using Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model {
    public class Song {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Length { get; set; }
        public string Genre { get; set; }

        public int? AlbumId { get; set; }
        public Album? Album { get; set; }

        public override string? ToString() {
            return $"Id: {Id}, Name: {Name}, Length: {Length.Hours}:{Length.Minutes:d2}, Genre: {Genre}, Album Id: {(AlbumId.HasValue ? AlbumId : "N/A")}";
        }
    }
}
