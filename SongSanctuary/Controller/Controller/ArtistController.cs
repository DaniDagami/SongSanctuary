using Data.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Controller {
    public class ArtistController : Controller {
        public static List<Artist> GetAll() {
            using(_appContext = new ApplicationDbContext()) {
                return _appContext.Artists.ToList();
            }
        }

        public Artist Get(int id) {
            using(_appContext = new ApplicationDbContext()) {
                return _appContext.Artists.Find(id);
            }
        }

        public void Add(Artist Artist) {
            using(_appContext = new ApplicationDbContext()) {
                _appContext.Artists.Add(Artist);
                _appContext.SaveChanges();
            }
        }

        public void Update(Artist Artist) {
            using(_appContext = new ApplicationDbContext()) {
                var item = _appContext.Artists.Find(Artist.Id);
                if(item != null) {
                    _appContext.Entry(item).CurrentValues.SetValues(Artist);
                    _appContext.SaveChanges();
                }
            }
        }

        public void Delete(int id) {
            using(_appContext = new ApplicationDbContext()) {
                var product = _appContext.Artists.Find(id);
                if(product != null) {
                    _appContext.Artists.Remove(product);
                    _appContext.SaveChanges();
                }
            }
        }

        public static void ListAll() {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Artists");
            Console.WriteLine(new string('-', 40));
            var artists = GetAll();
            foreach (var artist in artists) {
                Console.WriteLine(artist.ToString()); // TODO: make a ToString()
            }
            Console.WriteLine(new string('-', 40));
        }
    }
}
