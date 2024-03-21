using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongSanctuary.View {
    public class Band {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int MemberCount { get; set; }

        public ICollection<Artist> Artist { get; set;}
    }
}
