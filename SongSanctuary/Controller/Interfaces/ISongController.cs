using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Interfaces {
    public interface ISongController {
        List<Song> GetAll();
        Song Get(int id);
        void Add(Song song);
        void Update(Song song);
        void Delete(int id);
        void ListAll();
    }
}
