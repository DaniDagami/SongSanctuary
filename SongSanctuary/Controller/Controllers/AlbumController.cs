using Controller.Interfaces;
using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Controller {
    public class AlbumController : Controller, IAlbumController {

        public List<Album> GetAll() {
            using (_appContext = new ApplicationDbContext()) {
                return _appContext.Albums.ToList();
            }
        }

        public Album? Get(int? id) {
            using (_appContext = new ApplicationDbContext()) {
                if (id == null) {
                    return null;
                }
                return _appContext.Albums.Find(id);
            }
        }

        public void Add(Album Album) {
            using (_appContext = new ApplicationDbContext()) {
                _appContext.Albums.Add(Album);
                _appContext.SaveChanges();
            }
        }

        public void Update(Album Album) {
            using (_appContext = new ApplicationDbContext()) {
                var item = _appContext.Albums.Find(Album.Id);
                if (item != null) {
                    _appContext.Entry(item).CurrentValues.SetValues(Album);
                    _appContext.SaveChanges();
                }
            }
        }

        public void Delete(int id) {
            using (_appContext = new ApplicationDbContext()) {
                var product = _appContext.Albums.Find(id);
                if (product != null) {
                    _appContext.Albums.Remove(product);
                    _appContext.SaveChanges();
                }
            }
        }

        public void ListAll() {
            using (_appContext = new ApplicationDbContext()) {

                string type = "Albums";
                List<Album> albums = GetAll();
                List<string> albumInfos = albums.Select(a => a.ToString()).ToList();

                // print info relative to the longest album info string
                int maxInfoCharacterLength = albumInfos.Max(a => a.Length);
                Console.WriteLine(new string('-', maxInfoCharacterLength));
                Console.WriteLine(new string(' ', (maxInfoCharacterLength - type.Length) / 2) + type);
                Console.WriteLine(new string('-', maxInfoCharacterLength));

                albums.ForEach(x => Console.WriteLine(x.ToString())); // TODO: add BandName + { album.Band?.Name}");

                Console.WriteLine(new string('-', maxInfoCharacterLength));
            }
        }
    }
}
