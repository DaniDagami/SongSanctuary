using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model {
    public class Band {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int MemberCount { get; set; }
    
        public Band() {
            Artists = new List<Artist>();
            Albums = new List<Album>();
        }

        public override string ToString() {
            return $"Id: {Id}, Name: {Name}, Active: {(Active ? "Yes" : "No")}, Member Count: {MemberCount}";
        }

        public List<Artist> Artists { get; set;}
        public List<Album> Albums { get; set; }
    }
}
