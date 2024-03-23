using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Interfaces {
    public interface IAlbumController {
        List<Album> GetAll();
        Album? Get(int? id);
        void Add(Album album);
        void Update(Album album);
        void Delete(int id);
        void ListAll();
    }
}
