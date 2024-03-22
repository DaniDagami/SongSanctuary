using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Controller {
    public class SongController : Controller {
        public static List<Song> GetAll() {
            using(_appContext = new ApplicationDbContext()) {
                return _appContext.Songs.ToList();
            }
        }

        public Song Get(int id) {
            using(_appContext = new ApplicationDbContext()) {
                return _appContext.Songs.Find(id);
            }
        }

        public void Add(Song song) {
            using(_appContext = new ApplicationDbContext()) {
                _appContext.Songs.Add(song);
                _appContext.SaveChanges();
            }
        }

        public void Update(Song song) {
            using(_appContext = new ApplicationDbContext()) {
                var item = _appContext.Songs.Find(song.Id);
                if(item != null) {
                    _appContext.Entry(item).CurrentValues.SetValues(song);
                    _appContext.SaveChanges();
                }
            }
        }

        public void Delete(int id) {
            using(_appContext = new ApplicationDbContext()) {
                var product = _appContext.Songs.Find(id);
                if(product != null) {
                    _appContext.Songs.Remove(product);
                    _appContext.SaveChanges();
                }
            }
        }

        public static void ListAll() {
            AlbumController albumController = new AlbumController();
            var songs = GetAll();

            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Songs");
            Console.WriteLine(new string('-', 40));

            foreach (var song in songs) {
                Album? album = albumController.Get(song.AlbumId);
                Console.WriteLine(album == null ? song.ToString() : song.ToString() + $", AlbumId: {album.Id}, AlbumName: {album.Name}");
            }
            Console.WriteLine(new string('-', 40));
        }
    }
}
