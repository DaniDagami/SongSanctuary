using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Interfaces {
    public interface IArtistController {
        List<Artist> GetAll();
        Artist Get(int id);
        void Add(Artist artist);
        void Update(Artist artist);
        void Delete(int id);
        void ListAll();
    }
}
