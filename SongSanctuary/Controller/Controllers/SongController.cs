using Data;
using Data.Model;
using Controller.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Controller {
    public class SongController : Controller, ISongController {
        public List<Song> GetAll() {
            using (_appContext = new ApplicationDbContext()) {
                return _appContext.Songs.ToList();
            }
        }

        public Song Get(int id) {
            using (_appContext = new ApplicationDbContext()) {
                return _appContext.Songs.Find(id);
            }
        }

        public void Add(Song song) {
            using (_appContext = new ApplicationDbContext()) {
                _appContext.Songs.Add(song);
                _appContext.SaveChanges();
            }
        }

        public void Update(Song song) {
            using (_appContext = new ApplicationDbContext()) {
                var item = _appContext.Songs.Find(song.Id);
                if (item != null) {
                    _appContext.Entry(item).CurrentValues.SetValues(song);
                    _appContext.SaveChanges();
                }
            }
        }

        public void Delete(int id) {
            using (_appContext = new ApplicationDbContext()) {
                var product = _appContext.Songs.Find(id);
                if (product != null) {
                    _appContext.Songs.Remove(product);
                    _appContext.SaveChanges();
                }
            }
        }

        public void ListAll() {
            using (_appContext = new ApplicationDbContext()) {
                AlbumController albumController = new AlbumController();
                string type = "Songs";
                List<Song>? songs = GetAll();
                List<string>? songInfos = songs.Select(a => GetSongInfo(a, albumController)).ToList();

                // print info relative to the longest song info string
                int maxInfoCharacterLength = songInfos.Max(a => a.Length);
                Console.WriteLine(new string('-', maxInfoCharacterLength));
                Console.WriteLine(new string(' ', (maxInfoCharacterLength - type.Length) / 2) + type);
                Console.WriteLine(new string('-', maxInfoCharacterLength));

                songInfos.ForEach(a => Console.WriteLine(a));

                Console.WriteLine(new string('-', maxInfoCharacterLength));
            }
        }

        private static string GetSongInfo(Song song, AlbumController albumController) {
            Album? album = albumController.Get(song.AlbumId);
            string info = song.ToString();
            info += album == null ? $", Album Name: N/A" : $", Album Name: {album.Name}";
            return info;
        }
    }
}
