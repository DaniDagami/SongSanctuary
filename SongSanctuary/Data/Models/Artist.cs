using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model {
    public class Artist {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Alive { get; set; }
        public int? BandId { get; set; }

        public Band? Band { get; set; }

        public override string ToString() {
            return $"Id: {Id}, First Name: {FirstName}, Last Name: {LastName}, Alive: {(Alive ? "Yes" : "No")}, Band Id: {(BandId.HasValue ? BandId : "N/A")}";
        }
    }
}
