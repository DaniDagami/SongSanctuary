using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Controller {
    public class AlbumController {
        private ApplicationDbContext _appContext;
        public List<Album> GetAll() {
            using(_appContext = new ApplicationDbContext()) {
                return _appContext.Albums.ToList();
            }
        }

        public Album? Get(int? id) {
            using(_appContext = new ApplicationDbContext()) {
                if(id == null) {
                    return null;
                }
                return _appContext.Albums.Find(id);
            }
        }

        public void Add(Album Album) {
            using(_appContext = new ApplicationDbContext()) {
                _appContext.Albums.Add(Album);
                _appContext.SaveChanges();
            }
        }

        public void Update(Album Album) {
            using(_appContext = new ApplicationDbContext()) {
                var item = _appContext.Albums.Find(Album.Id);
                if(item != null) {
                    _appContext.Entry(item).CurrentValues.SetValues(Album);
                    _appContext.SaveChanges();
                }
            }
        }

        public void Delete(int id) {
            using(_appContext = new ApplicationDbContext()) {
                var product = _appContext.Albums.Find(id);
                if(product != null) {
                    _appContext.Albums.Remove(product);
                    _appContext.SaveChanges();
                }
            }
        }

        public void ListAll() {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Albums");
            Console.WriteLine(new string('-', 40));
            var albums = GetAll();
            foreach (var album in albums) {
                Console.WriteLine(album.ToString()); // TODO: add BandName + { album.Band?.Name}");
            }
            Console.WriteLine(new string('-', 40));
        }
    }
}
